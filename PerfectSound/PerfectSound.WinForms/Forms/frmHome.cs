﻿using PerfectSound.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerfectSound.WinForms.Forms
{
    public partial class frmHome : Form
    {
        private int childFormNumber = 0;
        APIService _UserService = new APIService("User");

        public frmHome()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void addEditSoundpodcastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSongAndPodcastAdd frmAddSongPod = new frmSongAndPodcastAdd();
            frmAddSongPod.MdiParent = this;
            frmAddSongPod.Show();
        }

        private async void frmHome_Load(object sender, EventArgs e)
        {
            homeToolStripMenuItem_Click(sender, e);

            var allusers = await _UserService.GetAll<List<User>>();

            var logeduser_type = allusers.Where(u => u.UserName == APIService.username).Select(uid => uid.UserType).FirstOrDefault();
            if (logeduser_type.Type != "Admin")
            {
                addEditSoundpodcastToolStripMenuItem.Enabled = false;
                addToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;
                addToolStripMenuItem2.Enabled = false;
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIndexHome frmIndexHome = new frmIndexHome();
            frmIndexHome.MdiParent = this;
            frmIndexHome.Show();
        }

        public static class isPodcastOrSong
        {
            public static bool isPodcast;
        }
        private void songsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isPodcastOrSong.isPodcast = false;
            ShowSongAndPodcastSearch();
        }

        private void podcastsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isPodcastOrSong.isPodcast = true;
            ShowSongAndPodcastSearch();
        }

        private void ShowSongAndPodcastSearch()
        {
            frmSongAndPodcastSearch frmSAPSearch = new frmSongAndPodcastSearch();
            frmSAPSearch.MdiParent = this;
            frmSAPSearch.Show();
        }

        private void allArtistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonSearch frmPerSearch = new frmPersonSearch();
            frmPerSearch.MdiParent = this;
            frmPerSearch.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonAdd frmPerAdd = new frmPersonAdd();
            frmPerAdd.MdiParent = this;
            frmPerAdd.Show();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUserAdd frmUsrAdd = new frmUserAdd();
            frmUsrAdd.MdiParent = this;
            frmUsrAdd.Show();
        }

        private void allUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserSearch _frmUserSearch = new frmUserSearch();
            _frmUserSearch.MdiParent = this;
            _frmUserSearch.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmNewsAdd _frmNewsAdd = new frmNewsAdd();
            _frmNewsAdd.MdiParent = this;
            _frmNewsAdd.Show();
        }

        private void allNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewsSearch _frmNewsSearch = new frmNewsSearch();
            _frmNewsSearch.MdiParent = this;
            _frmNewsSearch.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmlogin = new frmLogin();
            frmlogin.Show();
        }

        

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserAdd newuser = new frmUserAdd();
            newuser.MdiParent = this;
            newuser.Show();
        }

        private void allUsersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUserSearch allusers = new frmUserSearch();
            allusers.MdiParent = this;
            allusers.Show();
        }

        private void versesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerseAdd frmVerse = new frmVerseAdd();
            frmVerse.ShowDialog();
        }
    }
}
