$fn = 100;

roddia = 8;
enddia = 5;
rodlegnth = 20;
endlegnth = 5;

union(){
    cylinder(r = roddia/2, h = rodlegnth);
    translate([0,0,rodlegnth]){cylinder(r1 = roddia/2, r2 = enddia/2, h = endlegnth);}
}