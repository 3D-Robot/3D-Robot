//diameter of pin
pindia = 8;
//extrusion side
extrusionside = 26;
//distance between the two extrusions
extrusionsep = 5;
//Thickness of material around the extrusion
extrusionsurrond = 3;
//legnth of material going over the extrusion (covering the extrusion)
extrusioncover = 25;
// the width of the inside of the hinge
hingewidth = 40;
//thickness of material around pin
pinsurrond = (extrusionside+extrusionsurrond*2-pindia)/2;
//the offset of the hinge from the start of hinge joint
hingeoffset = 0;
// tolerance for the hinge radially
pinsurrondtol = .1;
//tolerance for the hinge axially
hingetol = .2;

module cap() {
    difference(){
        union(){
            translate([-(extrusionsep + extrusionside*2+extrusionsurrond*2)/2, -(extrusionside+extrusionsurrond*2)/2,0]){cube([extrusionsep + extrusionside*2+extrusionsurrond*2, extrusionside+extrusionsurrond*2,extrusioncover+extrusionsurrond]);}
        }
        
        union(){
            translate([-extrusionsep/2-extrusionside,-extrusionside/2,-1]){cube([extrusionside,extrusionside,extrusioncover + 1]);}
            translate([extrusionsep/2,-extrusionside/2,-1]){cube([extrusionside,extrusionside,extrusioncover + 1]);}
        }
    }
}

//cap();

module hingein(){
    difference(){
        union(){
            translate([-(hingewidth - hingetol/2)/2,0,0]){rotate(a = [0,90,0]){cylinder(r = (pindia+pinsurrond*2-pinsurrondtol*2)/2, h = hingewidth - hingetol/2);}}
            translate([-(hingewidth - hingetol/2)/2,-(pindia+pinsurrond*2)/2,0]){cube([hingewidth - hingetol/2,(pindia+pinsurrond*2),(pindia+pinsurrond*2)/2]);}
        }
        
        union(){
            translate([-(hingewidth - hingetol/2 + 1)/2,0,0]){rotate(a = [0,90,0]){cylinder(r = (pindia)/2, h = hingewidth - hingetol/2 + 1);}}
        }
    }
}

//hingein();

module hingeout(){
     difference(){
        union(){
            translate([-(extrusionsep + extrusionside*2+extrusionsurrond*2)/2,0,0]){rotate(a = [0,90,0]){cylinder(r = (pindia+pinsurrond*2-pinsurrondtol*2)/2, h = extrusionsep + extrusionside*2+extrusionsurrond*2);}}
            translate([-(extrusionsep + extrusionside*2+extrusionsurrond*2)/2,-(pindia+pinsurrond*2)/2,0]){cube([extrusionsep + extrusionside*2+extrusionsurrond*2,(pindia+pinsurrond*2),(pindia+pinsurrond*2)/2 + hingeoffset]);}
        }
        
        union(){
            translate([-(extrusionsep + extrusionside*2+extrusionsurrond*2 + 1)/2,0,0]){rotate(a = [0,90,0]){cylinder(r = (pindia)/2, h = extrusionsep + extrusionside*2+extrusionsurrond*2 + 1);}}
            
            translate([-(hingewidth + hingetol/2)/2,-(pindia+pinsurrond*2 + 1)/2,-(pindia+pinsurrond*2 + 1)/2]){cube([hingewidth + hingetol/2,(pindia+pinsurrond*2 + 1),(pindia+pinsurrond*2 + hingeoffset+ 1)]);}
        }
    }
}

module connection(){
    difference(){
        union(){
            translate([-(pinsurrond*2 + pinsurrondtol+ pindia)/2,0,0]){cylinder(r = (pindia + pinsurrond*2)/2, h = (extrusionsep + extrusionside*2+extrusionsurrond*2 - hingewidth )/ 2);}
            translate([(pinsurrond*2 + pinsurrondtol+ pindia)/2,0,0]){cylinder(r = (pindia + pinsurrond*2)/2, h = (extrusionsep + extrusionside*2+extrusionsurrond*2 - hingewidth )/ 2);}
            translate([-(pinsurrond*2 + pinsurrondtol+ pindia)/2,-(pindia + pinsurrond*2)/2,0]){cube([pinsurrond*2 + pinsurrondtol+ pindia,pindia + pinsurrond*2,(extrusionsep + extrusionside*2+extrusionsurrond*2 - hingewidth )/ 2]);}
        }
        
        union(){
            translate([-(pinsurrond*2 + pinsurrondtol+ pindia)/2,0,-.1]){cylinder(r = (pindia)/2, h = (extrusionsep + extrusionside*2+extrusionsurrond*2 - hingewidth )/ 2 + .2);}
            translate([(pinsurrond*2 + pinsurrondtol+ pindia)/2,0,-.1]){cylinder(r = (pindia)/2, h = (extrusionsep + extrusionside*2+extrusionsurrond*2 - hingewidth )/ 2 + .2);}
            translate([0,0,-.1]){cylinder(r = (pindia)/2, h = (extrusionsep + extrusionside*2+extrusionsurrond*2 - hingewidth )/ 2 + .2);}
        }
    }
}
rotate(a = [0,270,180]){translate([pinsurrond+pindia/2,0,0]){connection();}}

//hingeout();
/*
//lower
union(){
    translate([0,0,(pindia+pinsurrond*2)/2+extrusioncover+extrusionsurrond + hingeoffset]){rotate(a = [180,0,0]){cap();}}
    hingeout();
}
*/
//upper
rotate(a = [180,0,0]){union(){
        translate([0,0,(pindia+pinsurrond*2)/2+extrusioncover+extrusionsurrond]){rotate(a = [180,0,0]){cap();}}
    hingein();
}}