using Godot;
using System;
using System.Collections.Generic;

public partial class Building : Resource
{
        public string key = "building_debug";
        public string name = "Building Debug";
        public string roles;

        public enum Enum 
        {
                BartaliFarm01,
                BartaliFarm02,
                BartaliFarm03,
                BartaliFarm04,
                BartaliFarm05,
        }

        private static Dictionary<Enum, Building> dictionary = new Dictionary<Enum, Building>();

        static Building()
        {
                dictionary[Enum.BartaliFarm01] = LoadBartaliFarm01();
        }

        private static Building LoadBartaliFarm01()
        {
                Building resource = new Building();

                resource.key = "building_bartali_farm_01";
                resource.name = "Bartali Farm 01";

                return resource;
        }
}
