﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.helper;
using BoatClub.model;

namespace BoatClub.view
{
    class AddBoatView
    {
        private Helper helper;
        private MemberDAL memberDAL;
        private bool memberExists = true;

        public AddBoatView()
        {
            this.memberDAL = new MemberDAL();
            this.helper = new Helper();
        }

        public void showAddBoatMenu()
        {
            Console.Clear();
            this.helper.printDivider();
            Console.WriteLine("LÄGG TILL EN BÅT");
            this.helper.printDivider();
            Console.WriteLine("\nVälj medlemsnummer.\n");
        }

        public void showMemberList()
        {
            List<KeyValuePair<string, string>> listMembers = new List<KeyValuePair<string, string>>();
            listMembers = memberDAL.listMembers();

            foreach (var member in listMembers)
            {
                Console.WriteLine("{0}: {1}", member.Key, member.Value);
            }
        }

        public string getChoice()
        {
            //Returns selected member or S for start menu
            string choice = Console.ReadLine();
            try {
                List<KeyValuePair<string, string>> member = memberDAL.getMemberById(choice);
            }

            catch(Exception){
                memberExists = false;
            }
            return choice;
        }

        public bool doesMemberExist() {
            return memberExists;
        }

        public Boat addBoat(string selectedMember)
        {
            string boatType = "";
            string boatLength = ""; 
            
            Console.Clear();
            helper.printDivider();
            Console.WriteLine("LÄGG TILL EN BÅT");
            helper.printDivider();
            
            while (boatType == "")
            {
                helper.getBoatTypeMenu();
                boatType = helper.setBoatType(Console.ReadLine());
            }

            while(boatLength == ""){
                Console.Write("Ange båtens längd: \n"); 
                boatLength = Console.ReadLine();
            }
            
            Boat newBoat = new Boat(0, boatType, boatLength, selectedMember);
            return newBoat;
        }
    }
}
