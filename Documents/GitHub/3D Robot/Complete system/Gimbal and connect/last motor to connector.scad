//nema 23 or whatever faceplate
nemax = 42.3+.2;
nemay = nemax;
holesdist = 45;
gearholesdist = 31;
gearsize = 50;
nemaholesdia = 5;
gearholesdia = 5;
wallthickness = 5;
legnth = nemax + wallthickness*2;
frontthickness = 5;
gearshaftdia = 8;

//using hub we have the bolts dia and their radius and amount
hubboltsdia = 3;
numhubbolts = 4;
hubboltsplacementradius = 20;
hublegnth = 10;
hubradiusthickness = hubboltsplacementradius + 4;
hubnutdia = hubboltsdia*2;
hubnuthieght = hubboltsdia;

module lastmotorholder(){
difference(){
    union(){

//this is the motor mount
translate([wallthickness+nemax+wallthickness,-wallthickness-nemax,0]){rotate(a = [0,0,90]){
difference(){
    union(){
        //main cube
        translate([nemax+wallthickness,0,0]){cube([nemax + wallthickness*2, nemax+wallthickness*2,nemax+wallthickness*2]);
    }}
    
    union(){
        //two nema motors
        translate([nemax+wallthickness*2,-(5)-frontthickness,wallthickness]){cube([nemax,nemax+wallthickness*2 + 5,nemax]);}
        
        //shafts
        translate([wallthickness*2+nemax/2+nemax,wallthickness+nemax-2,wallthickness+nemax/2]){rotate(a = [270,0,0]){cylinder(r = gearshaftdia/2, h = frontthickness+5, $fn = 100);}}
        
//all holes
        for(i = [0:4]){
                    degx = cos(360/4*i+45);
                    degy = sin(360/4*i+45);
            translate([holesdist/2*degx+nemax+wallthickness*2+nemax/2,nemax+wallthickness-2,holesdist/2*degy+wallthickness+nemax/2]){rotate(a = [270,0,0]){cylinder(r = nemaholesdia/2, h = frontthickness+5, $fn = 100);}}
            
                    degx1 = cos(360/4*i+45);
                    degy1 = sin(360/4*i+45);
                        translate([gearholesdist/2*degx1+nemax+wallthickness*2+nemax/2,nemax+wallthickness-2,gearholesdist/2*degy1+wallthickness+nemax/2]){rotate(a = [270,0,0]){cylinder(r = gearholesdia/2, h = frontthickness+5, $fn = 100);}}
        }
        
    }
}}}

translate([wallthickness+nemax/2,wallthickness+nemax/2,-hublegnth+.01]){cylinder(r = hubradiusthickness, h = hublegnth, $fn =100);}
//end of first union
}

union(){
            //hub holes
        for(i = [0:numhubbolts])
        {
            translate([hubboltsplacementradius*cos((360/numhubbolts)*i) + (wallthickness+nemax/2),hubboltsplacementradius*sin((360/numhubbolts)*i) + (wallthickness+nemax/2),-hublegnth-2]){rotate(a = [0,0,0]){cylinder(r = hubboltsdia/2, h = wallthickness + 5 + hublegnth, $fn = 100);}}
            
            //nuts traps
                       translate([hubboltsplacementradius*cos((360/numhubbolts)*i) + (wallthickness+nemax/2),hubboltsplacementradius*sin((360/numhubbolts)*i) + (wallthickness+nemax/2),wallthickness-hubnuthieght+.1]){rotate(a = [0,0,0]){cylinder(r = hubnutdia/2, h = hubnuthieght, $fn = 6);}}
        }
        
        //if shafts extends past hub
        translate([nemax/2+wallthickness,nemax/2+wallthickness,-hublegnth-5]){rotate(a = [0,0,0]){cylinder(r = gearshaftdia/2, h = hublegnth + 5 + wallthickness+2, $fn = 100);}}
        
}
}}
translate([-wallthickness - nemax/2,- (0 + legnth)/2,hublegnth]){
lastmotorholder();}


//this is the hub

