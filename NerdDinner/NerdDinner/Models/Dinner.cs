using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using NerdDinner.Models;

namespace NerdDinner.Models
{
    public class Dinner
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required]
        public string Description { get; set; }

        public string Address { get; set; }

        public Country Country { get; set; }

        public int? CountryId { get; set; }

        [Phone]
        [StringLength(16)]
        public string Phone { get; set; }

        public string Host { get; set; }

        public string Guests { get; set; }

        public int countGuests()
        {
            int count = 0;
            if (Guests != null)
            {
                count = 1;
                for (int i = 0; i < Guests.Length; i++)
                {
                    if (Guests[i] == ',')
                    {
                        count++;
                    }
                }
                return count;
            }
            else
            {
                return 0;
            }
        }

        public void addGuest (string user)
        {
            string tempGuests = Guests;
            if (Guests != null)
            {
                tempGuests = tempGuests + ", " + user;
                Guests = tempGuests;
            }
            else
            {
                Guests = user;
            }
            return;
        }

        public string addGuestAndReturn(string user)
        {
            string tempGuests = Guests;
            string temp = "";
            if (Guests != null)
            {
                tempGuests = tempGuests + ", " + user;
                temp = tempGuests;
            }
            else
            {
                temp = user;
            }
            return temp;
        }

        public bool isGuestInList(string user)
        {
            string compareUser = "";
            if (countGuests() > 1)
            {
                for (int i = 0; i < Guests.Length; i++)
                {
                    if (Guests[i] == ',')
                    {
                        if(compareUser == user)
                        {
                            return true;
                        }
                    }
                    else if(Guests[i] == ' ')
                    {
                        compareUser = "";
                    }
                    else
                    {
                        compareUser = compareUser + Guests[i];
                    }
                }
                if(compareUser == user)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(countGuests() == 1)
            {
                if (Guests == user)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void removeGuest(string user)
        {
            string compareUser = "";
            string tempGuest1 = "";
            string tempGuest2 = "";
            int beginningOfUser = 0;
            int endOfUser = 0;
            if (isGuestInList(user) == true)
            {
                if(countGuests() > 1)
                {
                    for (int i = 0; i < Guests.Length; i++)
                    {
                        if (Guests[i] == ',' || i == Guests.Length - 1)
                        {
                            if(i == Guests.Length - 1)
                            {
                                compareUser = compareUser + Guests[i];
                            }
                            if (compareUser == user)
                            {
                                if(i == Guests.Length - 1)
                                {
                                    endOfUser = Guests.Length;
                                }
                                else
                                {
                                    endOfUser = i + 2;
                                }
                                if(beginningOfUser == 0)
                                {
                                    for (int x = endOfUser; x < Guests.Length; x++)
                                    {
                                        tempGuest1 = tempGuest1 + Guests[x];
                                    }
                                    Guests = tempGuest1;
                                    return;
                                }
                                else
                                {
                                    for (int x = 0; x < beginningOfUser; x++)
                                    {
                                        tempGuest1 = tempGuest1 + Guests[x];
                                    }
                                    for (int y = endOfUser; y < Guests.Length; y++)
                                    {
                                        tempGuest2 = tempGuest2 + Guests[y];
                                    }
                                    Guests = tempGuest1 + tempGuest2;
                                    return;
                                }
                            }
                            else
                            {
                                beginningOfUser = i + 2;
                            }
                        }
                        else if (Guests[i] == ' ')
                        {
                            compareUser = null;
                        }
                        else
                        {
                            compareUser = compareUser + Guests[i];
                        }
                    }
                    return;
                }
                else
                {
                    Guests = "";
                    return;
                }
            }
            else
            {
                return;
            }
        }

        public string removeGuestAndReturn(string user)
        {
            string compareUser = "";
            string tempGuest1 = "";
            string tempGuest2 = "";
            string tempGuests = "";
            int beginningOfUser = 0;
            int endOfUser = 0;
            if (isGuestInList(user) == true)
            {
                if (countGuests() > 1)
                {
                    for (int i = 0; i < Guests.Length; i++)
                    {
                        if (Guests[i] == ',' || i == Guests.Length - 1)
                        {
                            if (i == Guests.Length - 1)
                            {
                                compareUser = compareUser + Guests[i];
                            }
                            if (compareUser == user)
                            {
                                if (i == Guests.Length - 1)
                                {
                                    endOfUser = Guests.Length;
                                    beginningOfUser = beginningOfUser - 2;
                                }
                                else
                                {
                                    endOfUser = i + 2;
                                }
                                if (beginningOfUser == 0)
                                {
                                    for (int x = endOfUser; x < Guests.Length; x++)
                                    {
                                        tempGuest1 = tempGuest1 + Guests[x];
                                    }
                                    tempGuests = tempGuest1;
                                    return tempGuests;
                                }
                                else if (endOfUser == Guests.Length)
                                {
                                    for (int x = 0; x < beginningOfUser; x++)
                                    {
                                        tempGuest1 = tempGuest1 + Guests[x];
                                    }
                                    tempGuests = tempGuest1;
                                    return tempGuests;
                                }
                                else
                                {
                                    for (int x = 0; x < beginningOfUser; x++)
                                    {
                                        tempGuest1 = tempGuest1 + Guests[x];
                                    }
                                    for (int y = endOfUser; y < Guests.Length; y++)
                                    {
                                        tempGuest2 = tempGuest2 + Guests[y];
                                    }
                                    tempGuests = tempGuest1 + tempGuest2;
                                    return tempGuests;
                                }
                            }
                            else if(Guests[i] == ',')
                            {
                                beginningOfUser = i + 2;
                            }
                        }
                        else if (Guests[i] == ' ')
                        {
                            compareUser = null;
                        }
                        else
                        {
                            compareUser = compareUser + Guests[i];
                        }
                    }
                    tempGuests = Guests;
                    return tempGuests;
                }
                else
                {
                    tempGuests = null;
                    return tempGuests;
                }
            }
            else
            {
                tempGuests = Guests;
                return tempGuests;
            }
        }

        public string returnUsername(string email)
        {
            string username = "";
            char iterator;
            for (int i = 0; i < email.Length; i++)
            {
                iterator = email[i];
                if (iterator != '@')
                {
                    username = username + iterator;
                }
                else
                {
                    return username;
                }
            }
            return username;
        }
    }
}