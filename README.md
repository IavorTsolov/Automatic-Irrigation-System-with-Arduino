Automatic Irrigation System with Arduino
Project Overview

This project presents an intelligent automatic irrigation system based on Arduino R4 Minima. The system measures soil moisture using a sensor and automatically controls a water pump to maintain optimal moisture levels for plants.

The main goal is to reduce human involvement in plant care while preventing both overwatering and drought. The project is also an educational exercise focused on microcontrollers, sensors, basic electronics, and automated control logic.

Project Goals

Measure soil moisture in real time

Automatically control water supply based on predefined thresholds

Reduce manual plant watering

Provide a low-cost and expandable alternative to commercial irrigation systems

Gain hands-on experience with Arduino, sensors, and automation logic

Existing commercial solutions were analyzed, but this project focuses on a custom implementation that is simple, affordable, and easy to extend.

Development Stages
First Prototype

Platform: Micro:bit

Programming: MakeCode

Purpose: Initial testing and understanding of sensor behavior

Result: Functional but unstable for reliable irrigation control

Second Prototype (Final Version)

Platform: Arduino R4 Minima

Programming: Arduino IDE

Result: Stable, precise control and successful system implementation

Team and Roles

Presiyan Francheshkov

Hardware wiring

Sensor selection and testing

Physical system assembly

Iavor Tsolov

Software development and optimization

System logic

Documentation and testing

System Architecture

The system consists of three main modules:

Sensor Module

Soil moisture sensor

Provides analog input data to the microcontroller

Control Module

Arduino R4 Minima

Processes sensor data

Compares values against predefined moisture thresholds

Actuator Module

Relay module

Water pump

Activated automatically when soil moisture is below the minimum threshold

Control Logic

The soil moisture sensor measures current moisture levels

Arduino reads and analyzes the sensor value

If moisture is below the minimum threshold, the pump is turned on

Once the desired moisture level is reached, the pump is turned off

Technologies Used
Hardware

Arduino R4 Minima

Soil moisture sensor

Relay module

Water pump

Power supply

Connecting wires

Software

Arduino IDE

C/C++ (Arduino framework)

Resources

Official Arduino documentation

Online tutorials and examples

Practical testing and sensor calibration

Installation and Usage

Connect all hardware components according to the wiring diagram

Upload the source code to the Arduino using Arduino IDE

Power the system

Place the soil moisture sensor into the soil

Observe automatic pump activation

Adjust moisture threshold values in the code if needed

Results and Applications

The project successfully demonstrates a working automatic irrigation system that improves plant care and reduces manual effort. It is suitable for:

Houseplants

Greenhouses

Small gardens

Future Improvements

Wi-Fi connectivity

Mobile or web application for monitoring

Additional sensors (temperature, air humidity)

Data logging and analytics

Smarter irrigation algorithms
