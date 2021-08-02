$fn = 100;
pindia = 3;
pinsurrond = 2.5;
thickness = 3;

difference(){
    union(){
        cylinder(r = pindia/2 + pinsurrond, h = thickness);
    }
    
    union(){
        translate([0,0,-.5]){cylinder(r = pindia/2, h = thickness + 1);}
    }
}