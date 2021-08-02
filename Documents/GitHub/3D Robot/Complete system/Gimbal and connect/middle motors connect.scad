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
gearshaftdia = 13+1;

module holder(){
difference(){
    union(){
        //main cube
        cube([nemax*2 + wallthickness*3, nemax+wallthickness*2,nemax+wallthickness*2]);
    }
    
    union(){
        //two nema motors
        translate([nemax+wallthickness*2,-(5)-frontthickness,wallthickness]){cube([nemax,nemax+wallthickness*2 + 5,nemax]);}
        translate([wallthickness,wallthickness,-5-frontthickness]){cube([nemax,nemax,nemax+wallthickness*2+5]);}
        
        //shafts
        translate([wallthickness*2+nemax/2+nemax,wallthickness+nemax-2,wallthickness+nemax/2]){rotate(a = [270,0,0]){cylinder(r = gearshaftdia/2, h = frontthickness+5, $fn = 100);}}
        translate([wallthickness+nemax/2,wallthickness+nemax/2, nemax+wallthickness-2]){rotate(a = [0, 0,0]){cylinder(r = gearshaftdia/2, h = frontthickness + 5, $fn = 100);}}
        
//all holes
        for(i = [0:4]){
                    degx = cos(360/4*i+45);
                    degy = sin(360/4*i+45);
            translate([holesdist/2*degx+nemax+wallthickness*2+nemax/2,nemax+wallthickness-2,holesdist/2*degy+wallthickness+nemax/2]){rotate(a = [270,0,0]){cylinder(r = nemaholesdia/2, h = frontthickness+5, $fn = 100);}}
            
                    degx1 = cos(360/4*i+45);
                    degy1 = sin(360/4*i+45);
                        translate([gearholesdist/2*degx1+nemax+wallthickness*2+nemax/2,nemax+wallthickness-2,gearholesdist/2*degy1+wallthickness+nemax/2]){rotate(a = [270,0,0]){cylinder(r = gearholesdia/2, h = frontthickness+5, $fn = 100);}}
        }
        
                for(i = [0:4]){
                    degx = cos(360/4*i+45);
                    degy = sin(360/4*i+45);
            translate([holesdist/2*degx+wallthickness+nemax/2,holesdist/2*degy+wallthickness+nemax/2,nemax+wallthickness-2]){rotate(a = [0,0,0]){cylinder(r = nemaholesdia/2, h = frontthickness+5, $fn = 100);}}
            
                    degx1 = cos(360/4*i+45);
                    degy1 = sin(360/4*i+45);
                        translate([gearholesdist/2*degx1+wallthickness+nemax/2,gearholesdist/2*degy1+wallthickness+nemax/2,nemax+wallthickness-2]){rotate(a = [0,0,0]){cylinder(r = gearholesdia/2, h = frontthickness+5, $fn = 100);}}
        }
        
    }
}}

translate([-wallthickness - nemax/2,wallthickness + nemax/2,frontthickness + legnth]){rotate(a = [180,0,0]){
holder();}}

