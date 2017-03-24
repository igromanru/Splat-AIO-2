﻿using System;
using System.Windows.Forms;
using SplatAIO.Logic.Weapons;
using SplatAIO.Properties;

namespace SplatAIO.UI.Weapons
{
    public partial class WeaponEditForm : Form
    {
        public Weapon weapon;

        public WeaponEditForm()
        {
            InitializeComponent();
        }

        public WeaponEditForm(Weapon wep)
        {
            InitializeComponent();

            weapon = wep;
            weaponBox.SelectedIndex = WeaponDatabase.GetIndex(weapon.id);
            weaponBox.Enabled = false;
            turfInkedBox.Value = Convert.ToInt32(weapon.turfInked);
            newFlagBox.Checked = weapon.isNew;
        }

        private void saveBox_Click(object sender, EventArgs e)
        {
            // check if we're adding a new weapon
            if (weaponBox.Enabled)
            {
                var weaponsForm = (WeaponsForm) Owner;
                var selectedWeapon = WeaponDatabase.Weapons[weaponBox.SelectedIndex];

                // make sure this new weapon isn't already in the list
                foreach (var existingWeapon in weaponsForm.weapons)
                    if (selectedWeapon.id == existingWeapon.id)
                    {
                        // refuse to save
                        MessageBox.Show(Strings.WEAPON_EXISTS_TEXT);
                        return;
                    }

                weapon = selectedWeapon;
            }

            weapon.turfInked = Convert.ToUInt32(turfInkedBox.Value);
            weapon.isNew = newFlagBox.Checked;

            Close();
        }
    }
}