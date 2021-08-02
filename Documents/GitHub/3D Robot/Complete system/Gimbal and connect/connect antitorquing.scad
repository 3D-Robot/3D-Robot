motorboltdia = 4.5;
numofmotorbolts = 2;
motorboltdistdia = 35;
shaftdia = 26.5;
//the part has to avoid this part while extending outwards (usually the coupler with the screw)
thickestshaftdia = 20;
//includes everything including the coupler
shaftlegnth = 35;
//this is the thickness of the part going from the motor to the rail
shaftsurrond = 5;
raillegnth = 22.5;
//this is the thickness of the part that guides and stops the rotation of the connected part
railwidth = 14+.2;

//this is the hieght of the rail (in the z direction)
railhieght = 15;

//for the metal version
//thickness of sheet metal
sheetthickness = 3.5;
//the width of the sheet
sheetwidth = 30;

metal = 1;

//we also have a heater that is composed of thin wire heater with double faced tape to aluminum foil and foam on top


 module prism(l, w, h){
       polyhedron(
               points=[[0,0,0], [l,0,0], [l,w,0], [0,w,0], [0,w,h], [l,w,h]],
               faces=[[0,1,2,3],[5,4,3,2],[0,4,5,1],[0,3,4],[5,2,1]]
               );
       }
       

    totalwidth = motorboltdistdia + motorboltdia *2 + shaftsurrond*2 + sheetthickness*2;
translate([-totalwidth/2, 0, -sheetwidth/2]){
    difference(){
        union(){
    //use seven cubes instead of importing dxf
    translate(){cube([totalwidth, sheetthickness,sheetwidth]);}
    translate([0,sheetthickness,0]){cube([sheetthickness, shaftlegnth, sheetwidth]);}
    translate([motorboltdistdia + motorboltdia *2 + shaftsurrond*2 + sheetthickness,sheetthickness,0]){cube([sheetthickness, shaftlegnth, sheetwidth]);}
    translate([0,shaftlegnth + sheetthickness,0]){cube([totalwidth,sheetthickness,sheetwidth]);}
    translate([(totalwidth - railwidth)/2-sheetthickness,shaftlegnth + sheetthickness,(sheetwidth - railhieght)/2]){cube([sheetthickness,raillegnth + sheetthickness,railhieght]);}
    translate([totalwidth - (totalwidth - railwidth)/2,shaftlegnth + sheetthickness,(sheetwidth - railhieght)/2]){cube([sheetthickness,raillegnth + sheetthickness,railhieght]);}
    translate([(totalwidth - railwidth)/2-sheetthickness,(shaftlegnth + sheetthickness) + raillegnth + sheetthickness,(sheetwidth - railhieght)/2+railhieght]){rotate(a = [180,90,0]){prism(railhieght,raillegnth,(totalwidth - railwidth)/2 - sheetthickness);}}
    translate([(totalwidth - ((totalwidth - railwidth)/2 - sheetthickness)),(shaftlegnth + sheetthickness) + raillegnth + sheetthickness,(sheetwidth - railhieght)/2]){rotate(a = [180,90+180,0]){prism(railhieght,raillegnth,(totalwidth - railwidth)/2 - sheetthickness);}}
}

union(){
    translate([totalwidth/2,-.1,sheetwidth/2]){rotate(a = [270,0,0]){
        translate([0,0,0]){cylinder(r = shaftdia/2, h = 10, $fn = 100);}
        translate([-motorboltdistdia/2, 0, 0]){cylinder(r = motorboltdia/2, h = 10, $fn = 100);}
        translate([motorboltdistdia/2, 0, 0]){cylinder(r = motorboltdia/2, h = 10, $fn = 100);}
    }}
        translate([totalwidth/2-railwidth/2,shaftlegnth + sheetthickness-.5,sheetwidth/2-railhieght/2]){cube([railwidth,sheetthickness + 1,railhieght]);}
}
}}