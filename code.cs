#include <Wire.h>
#include <hd44780.h>
#include <hd44780ioClass/hd44780_I2Cexp.h>

hd44780_I2Cexp lcd;

const int sensorPin = A0;
const int pumpPin = 9;
const int DRY_START = 400;
const int WET_STOP  = 200;

unsigned long pumpStartTime = 0;
const unsigned long maxPumpTime = 60000;
const unsigned long cooldownTime = 30000;
unsigned long lastPumpEnd = 0;

bool pumpRunning = false;
unsigned long lastLCDUpdate = 0;
unsigned long lastLCDCheck = 0;

void setup() {
  Serial.begin(9600);
  pinMode(pumpPin, OUTPUT);
  digitalWrite(pumpPin, LOW);

  lcd.begin(16,2);
  lcd.backlight();
  lcd.setCursor(0,0);
}

void loop() {
  unsigned long currentTime = millis();
  int moisture = analogRead(sensorPin);

  // Pump control logic
  if(pumpRunning) {
    if(moisture <= WET_STOP || currentTime - pumpStartTime >= maxPumpTime) {
      digitalWrite(pumpPin, LOW);
      pumpRunning = false;
      lastPumpEnd = currentTime;
    }
  } else if(currentTime - lastPumpEnd >= cooldownTime && moisture >= DRY_START) {
    digitalWrite(pumpPin, HIGH);
    pumpRunning = true;
    pumpStartTime = currentTime;
  }

  // Wetness %
  int wetPercent = map(moisture, DRY_START, WET_STOP, 0, 100);
  wetPercent = constrain(wetPercent,0,100);

  // -----------------------------
  // LCD Update every 500ms
  // -----------------------------
  if(currentTime - lastLCDUpdate >= 500) {
    lastLCDUpdate = currentTime;

    // Row 1: Wetness % + bar
    lcd.setCursor(0,0);
    lcd.print("Wet:");
    lcd.print(wetPercent);
    lcd.print("%   ");

    // Row 2: Pump + moisture
    lcd.setCursor(0,1);
    lcd.print(pumpRunning ? "PUMP: ON " : "PUMP: OFF");
    lcd.setCursor(10,1);
    lcd.print("M:");
    lcd.print(moisture);
  }

  // -----------------------------
  // LCD Auto-recovery every 10s
  // -----------------------------
  if(currentTime - lastLCDCheck >= 10000) {
    lastLCDCheck = currentTime;
    // Try to ping the LCD (just set cursor)
    lcd.setCursor(0,0);
  }

  delay(50); // small delay, non-blocking
}
