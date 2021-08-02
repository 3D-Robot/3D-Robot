motordia = 43+.5;
motorlegnth = 120;
legnth = 50;
shaftdia = 8;
//if using hub change to hublength
shaftlegnth = 5;
wallthickness = 3;
shaftwallthickness = 10;
shaftboltdia = 5;
nuthieght = shaftboltdia;
nutdia = shaftboltdia * 2;
clampboltdia = 3;
clampboltsurrond = 4;
clampwidth = clampboltdia + clampboltsurrond;
splitwidth = 3;
wireoutletx = 6;
wireoutlety = 4;

//hub connections options
usehub = 1;
hubdia = 45;
numhubbolts = 4;
gearshaftdia = shaftdia;
hublegnth = 5;
hubboltsplacementradius = (.85*25.4)/2;
hubboltsdia = 3;
hubnuthieght = 3;
hubnutdia = 6;



difference(){
    union(){
        //the motor hold
        translate([0,0,shaftlegnth]){rotate(){cylinder(r = motordia/2+wallthickness, h = legnth, $fn = 100);}}
        if(usehub == 0)
        {
        //the shaft
       translate([0,0,0]){rotate(){cylinder(r = shaftdia/2 + shaftwallthickness, h = shaftlegnth, $fn = 100);}}
   }
        //the clamp
        translate([motordia/2,-3*wallthickness/2,shaftlegnth+legnth-clampwidth]){cube([clampwidth+wallthickness,wallthickness+wallthickness*2,clampwidth]);}
        
        if(usehub == 1)
        {
            //hubbase
            translate(){cylinder(r = hubdia/2, h = hublegnth,$fn = 100);}
        }
        
    }
    
    union(){
        //motor
        translate([0,0,shaftlegnth+wallthickness-.01]){cylinder(r = motordia/2, h = motorlegnth, $fn = 100);}
      
        if(usehub == 1)
        {
        //the hub holes
        for(i = [0:numhubbolts])
        {
            translate([hubboltsplacementradius*cos((360/numhubbolts)*i) + (0),hubboltsplacementradius*sin((360/numhubbolts)*i) + (0),-2]){rotate(a = [0,0,0]){cylinder(r = hubboltsdia/2, h = wallthickness + 5 + hublegnth, $fn = 100);}}
            
            //nuts traps
                       translate([hubboltsplacementradius*cos((360/numhubbolts)*i) + (0),hubboltsplacementradius*sin((360/numhubbolts)*i) + (0),hublegnth+wallthickness+.1-hubnuthieght]){rotate(a = [0,0,0]){cylinder(r = hubnutdia/2, h = hubnuthieght, $fn = 6);}}
        }
        
                //if shafts extends past hub
        translate([0,0,-1]){rotate(a = [0,0,0]){cylinder(r = gearshaftdia/2, h = hublegnth + 5 + wallthickness+2, $fn = 100);}}
    }
        
        //shaft
        if(usehub == 0 )
        {
     {
        translate([0-.01,0,-2]){cylinder(r = shaftdia/2, h = shaftlegnth + wallthickness+5, $fn = 100);}
    
  
    translate([2,0,shaftlegnth/2]){rotate(a = [0,90,0]){cylinder(r = shaftboltdia/2, h = shaftdia+wallthickness +5,$fn = 100);}}
    translate([shaftdia/2,0,shaftlegnth/2]){rotate(a = [0,90,0]){cylinder(r = nutdia/2, h = nuthieght,$fn = 6);}}
    translate([shaftdia/2,-nutdia/2,-.1]){cube([nuthieght,nutdia,shaftlegnth/2]);}
}}
   
    //the split and the clamp
    translate([motordia/2-1,-splitwidth/2,shaftlegnth-.1]){cube([wallthickness+clampwidth + 5, splitwidth, motorlegnth]);}
  
    //wireoutlet
    translate([motordia/2-1,-wireoutletx/2,shaftlegnth-.1]){cube([wallthickness + 5,wireoutletx,wireoutlety+wallthickness]);}
    
    //clamp holes
    translate([motordia/2+wallthickness+clampboltdia/2+clampboltsurrond/4,-3*wallthickness/2-2,shaftlegnth+legnth-clampwidth+clampwidth/2]){rotate(a = [270,0,0]){cylinder(r = clampboltdia/2, h = wallthickness*2+splitwidth+5, $fn = 100);}}}

}
