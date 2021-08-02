$fn = 100;
outerdia = 100;
centerholedia = 5;
smalldia = 10;
numofwheels = 10;
wheellegnth = 15;
thickness = 5;

module omniwheel(){
difference(){
    union(){
        cylinder(r = outerdia/2, h = thickness);
    }
    
    union(){
    translate([0,0,-1]){cylinder(r = centerholedia/2, h = thickness+2);}
        for(i = [0:numofwheels]){
        rotate(a = [0,0,i*36]){translate([-wheellegnth/2,outerdia/2-smalldia*1.5/2,-1]){cube([wheellegnth,smalldia*1.5,thickness+2]);}}
    }
    }
}
}

pindia = 1;
module cylinders(){
    difference(){
        union(){
            translate([0,0,0]){cylinder(r= smalldia/2, h = wheellegnth);}
        }
        
        union(){           translate([0,0,-1]){cylinder(r = pindia/2, h = wheellegnth+2);}
        }
    }
}

module pin()
{
   $fn = 10;     rotate_extrude(angle=360){
        translate([outerdia/2-smalldia/3,0]){circle(d = pindia);}}
        translate([0,-(outerdia/2-smalldia/2),0]){rotate(a = [90,0,65]){cylinder(r = pindia/2, h = smalldia*2);}}
        translate([0,-(outerdia/2-smalldia/2),0]){rotate(a = [90,0,-65]){cylinder(r = pindia/2, h = smalldia*2);}}
}


module roundoff(){
    difference(){
        union(){
            translate([0,0,0]){cylinder(r = (outerdia/2-smalldia/3)+smalldia+5, h = thickness*5);}
        }
        
        union(){
            translate([0,0,-1]){cylinder(r = (outerdia/2-smalldia/3)+smalldia/2, h = thickness*5+2);
        }}
    }
}

    module completeomniwheel(){
        difference(){
            union(){
        translate([0,0,-thickness/2]){omniwheel();}
translate([0,0,thickness+1]){rotate(a = [0,0,36/2]){omniwheel();}}
        
        for(i = [0:numofwheels]){
        rotate(a = [0,0,i*36]){translate([-wheellegnth/2,outerdia/2-smalldia/3,-1]){rotate(a = [0,90,0]){cylinders();}}}
            translate([0,0,thickness*1.5+1]){    for(i = [0:numofwheels]){
        rotate(a = [0,0,i*36+36/2]){translate([-wheellegnth/2,outerdia/2-smalldia/3,-1]){rotate(a = [0,90,0]){cylinders();}}}}
    }
    }}
    union(){
    translate([0,0,-thickness*2]){roundoff();}
        
        translate([0,0,0]){rotate(a = [0,0,36/2]){pin();}}
        translate([0,0,thickness*1.5+1]){pin();}
    }
}
}
    
completeomniwheel();
