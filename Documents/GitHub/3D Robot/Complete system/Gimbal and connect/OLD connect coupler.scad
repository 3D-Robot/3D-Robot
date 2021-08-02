//this is the coupler to be machined from aluminum to connect the connect geared motor to the threaded rod 
//we are using a square bar instead of a round one should be okay

x = 25.4*1.5;
y = x;
gearedshaftdia = 12.7;
connectdia = 15;
holdingscrewdia = 5;
shaftlegnth = 15;
connectlegnth = 15;
square = 0;
//if it's plastic add nut traps
plastic = 1;
nuthieght = holdingscrewdia;
//the angle between the bolts
angle = 60;

difference(){
    totallegnth = shaftlegnth + connectlegnth;
    union(){
        if(square == 1)
        {
        translate([-x/2, -y/2,0]){cube([x,y,totallegnth]);}
    }
    else if(square == 0)
    {
        translate([0,0,0]){cylinder(r = x/2,h = totallegnth, $fn = 100);}
    }
    else
    {
    }
    }
    
    union (){
        translate([0,0,-1+.1]){cylinder(r = gearedshaftdia/2, h = shaftlegnth + 1, $fn = 100);}
        translate([0,0,shaftlegnth]){cylinder(r = connectdia/2, h = connectlegnth + 1, $fn = 100);}
        
        translate([0,0,shaftlegnth/2]){
        translate(){rotate(a = [0,90,0]){cylinder(r = holdingscrewdia/2, h = x/2 + 1, $fn = 100);}}
        translate(){rotate(a = [0,90,angle]){cylinder(r = holdingscrewdia/2, h = x/2 + 1, $fn = 100);}}
    }
        
        translate([0,0,shaftlegnth + connectlegnth/2]){
        translate(){rotate(a = [0,90,0]){cylinder(r = holdingscrewdia/2, h = x/2 + 1, $fn = 100);}}
        translate(){rotate(a = [0,90,angle]){cylinder(r = holdingscrewdia/2, h = x/2 + 1, $fn = 100);}}
    }
    
    if(plastic == 1)
    {
        translate([x/6,0,shaftlegnth/2]){rotate(a = [0,90,0]){nuttrap(shaftlegnth);}}
                translate([x/5*cos(angle),x/5*sin(angle),shaftlegnth/2]){rotate(a = [0,90,angle]){nuttrap(shaftlegnth);}}
                translate([0,0,shaftlegnth+connectlegnth/2+shaftlegnth/2]){rotate(a = [180,0,90]){
                            translate([x/5*cos(90-angle),x/5*sin(90-angle),shaftlegnth/2]){rotate(a = [0,90,90-angle]){nuttrap(connectlegnth/2);}}
                translate([0,x/5,shaftlegnth/2]){rotate(a = [0,90,90]){nuttrap(connectlegnth);}}}}
    }
    }
}
module nuttrap(legnth){
            translate([0,-holdingscrewdia,0]){cube([legnth+1,holdingscrewdia*2,nuthieght]);}
        translate([0,0,0]){cylinder(r = holdingscrewdia, h = nuthieght, $fn = 6);}
}