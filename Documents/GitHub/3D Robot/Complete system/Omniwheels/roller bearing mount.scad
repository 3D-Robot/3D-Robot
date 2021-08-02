rollerbearingdia = 24;
rollerbearingsurrond = 5;
//the middle hole of the bearing
shaftdia = 8;
// distance from the ground to the center of the roller bearing
rollerbearinghieght = 21;
feetthickness = 3;
feetboltdia = 3;
feetboltsurrond = 3;
//the width of the whole thing
width = 8;
//thin part holding the roller bearing from falling out axially
rollerholder = .3;

difference(){
    union(){
        translate([-(rollerbearingdia + rollerbearingsurrond*2)/2, 0, feetthickness]){cube([rollerbearingdia + rollerbearingsurrond*2, width,rollerbearinghieght-feetthickness]);}
        translate([-(rollerbearingdia + rollerbearingsurrond*2 + feetboltdia * 2 + feetboltsurrond *4)/2, 0, 0]){cube([rollerbearingdia + rollerbearingsurrond*2 + feetboltdia * 2 + feetboltsurrond *4, width, feetthickness]);}
        translate([0,0,rollerbearinghieght]){rotate(a = [270,0,0]){cylinder(r = (rollerbearingdia + rollerbearingsurrond * 2)/2 , h = width, $fn = 100);}}
    }
    
    union(){
       translate([0,rollerholder,rollerbearinghieght]){rotate(a = [270,0,0]){cylinder(r = (rollerbearingdia)/2 , h = width + 1, $fn = 100);}} 
              translate([0,-.5,rollerbearinghieght]){rotate(a = [270,0,0]){cylinder(r = (shaftdia)/2 , h = width + 1, $fn = 100);}} 
              translate([rollerbearingdia/2 + rollerbearingsurrond + feetboltsurrond + feetboltdia/2, width/2, -.5]){cylinder(r = feetboltdia/2, h = feetthickness + 1, $fn = 100);}
              translate([-(rollerbearingdia/2 + rollerbearingsurrond + feetboltsurrond + feetboltdia/2), width/2, -.5]){cylinder(r = feetboltdia/2, h = feetthickness + 1, $fn = 100);}
    }
}

//integrated plastic bearing
//translate([0,.55,rollerbearinghieght]){rotate(a = [270,0,0]){import("608v2_0.stl");}}