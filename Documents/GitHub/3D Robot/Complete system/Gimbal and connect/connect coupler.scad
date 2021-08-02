$fn = 100;
motorshaftdia = 8;
connectboltdia = 8;
shaftsurrond = 5;
couplerlegnth = 20;

difference(){
    union(){
        cylinder(r = (motorshaftdia + shaftsurrond * 2)/2, h = couplerlegnth);
    }
    
    union(){
        translate([0,0,-.1]){cylinder(r = motorshaftdia/2, h = couplerlegnth/2 + .1);}
        translate([0,0,couplerlegnth/2-.1]){cylinder(r = connectboltdia/2, h = couplerlegnth/2 + .2);}
    }
}