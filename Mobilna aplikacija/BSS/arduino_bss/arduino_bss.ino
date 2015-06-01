#include "DHT.h"
#include <SFE_BMP180.h>
#include <Wire.h>
#include <SoftwareSerial.h>

// D10 Tx
// D11 Rx
int tx = 10;
int rx = 11;

SoftwareSerial bt(rx, tx);

#define DHTPIN 2   
#define DHTTYPE DHT22   // DHT 22  (AM2302)

SFE_BMP180 pritisak;
DHT dht(DHTPIN, DHTTYPE);

float pritisakNaNivouMora = 1013.25f;
float temperatura = 0.0;
float vlaznost = 0.0;
float nadmorskaVisina = 0.0;
float atmosferskiPritisak = 0.0;

void izmjeri();
void posaljiNaPC();
double getPressure();
void posaljiViaBT();

void setup() {
  Serial.begin(4800); 
  bt.begin(9600);
  Serial.println("DHT22 && BMP180 test!"); 
  dht.begin();
  pritisak.begin();
}

void loop() {
  delay(2000);
  izmjeri();
  posaljiNaPC();
  posaljiViaBT();
}

void izmjeri() {
  float h = dht.readHumidity();
  float t = dht.readTemperature();
  if (!(isnan(h) || isnan(t))) {
  temperatura = t;
  vlaznost = h;
  }
 double p = getPressure();
 if(p > 0) {
 atmosferskiPritisak = (float)p;
 nadmorskaVisina = pritisak.altitude(atmosferskiPritisak, pritisakNaNivouMora);
 }
}
void posaljiNaPC() {
  Serial.print("Temperatura: ");
  Serial.print(temperatura);
  Serial.print(" *C\n");
  Serial.print("Relativna vlaznost: ");
  Serial.print(vlaznost);
  Serial.print(" %\n");
  Serial.print("Pritisak: ");
  Serial.print(atmosferskiPritisak);
  Serial.print(" mb\n");
  Serial.print("Nadmorska visina: ");
  Serial.print(nadmorskaVisina);
  Serial.print(" m\n");
  Serial.println();
}

double getPressure()
{
  char status;
  double T, P, p0, a;
  
  status = pritisak.startTemperature();
  if (status != 0)
  {
    delay(status);
    status = pritisak.getTemperature(T);
    if (status != 0)
    {
      status = pritisak.startPressure(3);
      if (status != 0)
      {
        delay(status);
        status = pritisak.getPressure(P,T);
        if (status != 0) return(P);
      }
    }
  }
  return -1;
}

void posaljiViaBT(){
  bt.print("T");
  bt.print(temperatura);
  bt.println();
 // bt.print("\n");
  bt.print("R");
  bt.print(vlaznost);
  bt.println();
 // bt.print("\n");
  bt.print("P");
  bt.print(atmosferskiPritisak);
  bt.println();
 // bt.print("\n");
  bt.print("N");
  bt.print(nadmorskaVisina);
  bt.println();
  bt.println();
  //bt.print("\n");
}
