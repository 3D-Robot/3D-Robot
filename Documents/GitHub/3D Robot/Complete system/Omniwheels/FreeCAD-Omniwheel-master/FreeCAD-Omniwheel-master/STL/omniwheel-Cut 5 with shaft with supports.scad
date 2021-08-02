difference(){
rotate(a = [90,0,0]){import("omniwheel-Cut 5 with shaft.stl");}
translate([0,0,-50]){cylinder(r = 11/2, h = 100, $fn = 100);}
}
r = 47;
for(i = [0:10]){
translate([r*cos(360/10*i),r*sin(360/10*i),-5]){cylinder(r = 2, h = 10);}
}