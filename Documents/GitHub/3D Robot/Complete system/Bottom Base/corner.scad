
boxx = 250;
boxy = 250;
boxz = 250;
extrusionx = 26;
extrusiony = 26;
extrusionwall = 2;
extrusionsurrond = 5;
extrusionholder = extrusionsurrond*5;

module square(){
    difference(){
        union(){
            translate([-(extrusionx + extrusionsurrond*2)/2,-(extrusiony + extrusionsurrond*2)/2,0]){cube([extrusionx + extrusionsurrond*2, extrusiony + extrusionsurrond*2, extrusionholder]);}
        }
        
        union(){
            translate([-extrusionx/2,-extrusiony/2,extrusionsurrond]){cube([extrusionx, extrusiony,extrusionholder]);}
        }
    }
    
}

difference(){
    union(){
square();
translate([(extrusionx + extrusionsurrond*2)/2+(extrusionx + extrusionsurrond*2)/2*sin(45)-extrusionsurrond,0,(extrusionx + extrusionsurrond*2)/2*cos(45)]){rotate(a = [0,45,0]){square();}}
            translate([(extrusionx + extrusionsurrond*2)/2,-(extrusiony + extrusionsurrond*2)/2,0]){cube([extrusionx + extrusionsurrond*2, extrusiony + extrusionsurrond*2, extrusionholder]);}
        }
        
        union(){
            translate([-extrusionx/2*0+extrusionx*cos(44),-extrusiony/2,extrusionx*sin(44)+extrusionsurrond]){rotate(a = [0,44,0]){
                cube([extrusionx, extrusiony, 100]);}}
        }
            
 }