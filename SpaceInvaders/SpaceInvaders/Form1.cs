
namespace SpaceInvaders
{
    public partial class Form1 : Form
    {
        int spaceshipSpeed = 7;
        string direction = "none";
        bool isFiring = false;
        //int noOfProjectiles = 0;
        List <PictureBox> pictureBoxesLeft= new List<PictureBox>();
        List<PictureBox> pictureBoxesRight = new List<PictureBox>();
        List<PictureBox> pictureBoxesBombers = new List<PictureBox>();
        int projectileLeftStartX = 0;
        int projectileLeftStartY = 0;
        int projectileRightStartX = 0;
        int projectileRightStartY = 0;
        Size projectileSize = new Size(19, 21);
        int projectileYDecrement = 27;
        Bitmap bulletBitmap = new Bitmap(Properties.Resources.goldbullet);
        int startXbomber = 10;
        int startYbomber = 10;
        Size bomberSize = new Size(60, 60);
        int incrementBomberX = 60;
        Bitmap bomberBitmap = new Bitmap(Properties.Resources.UK_bomber);
        int score = 0;
        int level = 1;
        

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            //set initial location for picture boxes, from the location of the fighter
            projectileLeftStartX = pictureBoxSpaceship.Location.X + 9;
            projectileLeftStartY = pictureBoxSpaceship.Location.Y - 27;
            projectileRightStartX = pictureBoxSpaceship.Location.X + 46;
            projectileRightStartY = pictureBoxSpaceship.Location.Y - 27;

            //add initial bombers, row wise and column wise
            this.populateBombers();

            //set score and level
            this.labelScore.Text = "Score: " + this.score.ToString();
            this.labelLevel.Text = "Level: " + this.level.ToString();
        }

        private void Form1_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                //stop spaceship animation timer
                this.timerFighter.Stop();

                //reset direction
                this.direction = "none";
            }
            else if (e.KeyCode == Keys.Right)
            {
                //stop spaceship animation timer
                this.timerFighter.Stop();

                //reset direction
                this.direction = "none";
            }
            else if (e.KeyCode == Keys.Space)
            {
                //stop firing and hide the projectile
                this.isFiring = false;
                this.timerProjectile.Stop();
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                //set direction of spaceship animation
                this.direction = "left";

                //start animation timer
                this.timerFighter.Start();
            }
            else if (e.KeyCode == Keys.Right)
            {
                //set direction of spaceship animation
                this.direction = "right";

                //start animation timer
                this.timerFighter.Start();
            }
            else if (e.KeyCode == Keys.Space)
            {
                //set flag for firing, start projectile timer, show projectiles
                this.isFiring = true;

                if(this.timerProjectile.Enabled == false)
                {
                    this.timerProjectile.Start();
                }

                if (this.timerHideBullets.Enabled == false)
                {
                    this.timerHideBullets.Start();
                }
            }
        }


        //timer event handler
        private void timerSpaceShip_Tick(object sender, EventArgs e)
        {
            //move spaceship according to direction 

            //test which direction is chosen
            if (this.direction == "left")
            {
                //test if the spaceship will get out of bounds if moving to the left
                if(this.pictureBoxSpaceship.Location.X >= spaceshipSpeed)
                {
                    Point tempPoint = new Point(this.pictureBoxSpaceship.Location.X - spaceshipSpeed, this.pictureBoxSpaceship.Location.Y);
                    this.pictureBoxSpaceship.Location = tempPoint;
                }
            }
            else if (this.direction == "right")
            {
                //test if the spaceship will get out of bounds if moving to the right
                if (this.pictureBoxSpaceship.Location.X + this.pictureBoxSpaceship.Width < this.Width - 25)
                {
                    Point tempPoint = new Point(this.pictureBoxSpaceship.Location.X + spaceshipSpeed, this.pictureBoxSpaceship.Location.Y);
                    this.pictureBoxSpaceship.Location = tempPoint;
                }
            }

            //update coordinates for projectiles according to the fighter location
            projectileLeftStartX = pictureBoxSpaceship.Location.X + 9;
            projectileLeftStartY = pictureBoxSpaceship.Location.Y - 27;
            projectileRightStartX = pictureBoxSpaceship.Location.X + 46;
            projectileRightStartY = pictureBoxSpaceship.Location.Y - 27;
        }

        private void timerProjectile_Tick(object sender, EventArgs e)
        {
            try
            {
                //only create a new bullet if there are maximally 10 projectiles on screen
                {
                    if(pictureBoxesLeft.Count < 3)
                    {
                        pictureBoxesLeft.Add(new PictureBox());
                        pictureBoxesLeft[pictureBoxesLeft.Count - 1].Location = new Point(projectileLeftStartX, projectileLeftStartY - (pictureBoxesLeft.Count - 1 * projectileYDecrement));
                        pictureBoxesLeft[pictureBoxesLeft.Count - 1].Size = projectileSize;
                        pictureBoxesLeft[pictureBoxesLeft.Count - 1].BackColor = Color.Transparent;
                        pictureBoxesLeft[pictureBoxesLeft.Count - 1].Image = this.bulletBitmap;
                        pictureBoxesLeft[pictureBoxesLeft.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBoxesLeft[pictureBoxesLeft.Count - 1].Visible = true;
                        this.Controls.Add(pictureBoxesLeft[pictureBoxesLeft.Count - 1]);

                        pictureBoxesRight.Add(new PictureBox());
                        pictureBoxesRight[pictureBoxesRight.Count - 1].Location = new Point(projectileRightStartX, projectileRightStartY - (pictureBoxesRight.Count - 1 * projectileYDecrement));
                        pictureBoxesRight[pictureBoxesRight.Count - 1].Size = projectileSize;
                        pictureBoxesRight[pictureBoxesRight.Count - 1].BackColor = Color.Transparent;
                        pictureBoxesRight[pictureBoxesRight.Count - 1].Image = this.bulletBitmap;
                        pictureBoxesRight[pictureBoxesRight.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBoxesRight[pictureBoxesRight.Count - 1].Visible = true;
                        this.Controls.Add(pictureBoxesRight[pictureBoxesRight.Count - 1]);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //animate the bullets and hide them when reaching a bomber or the upper edge of the form
        private void timerHideBullets_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.pictureBoxesLeft.Count >= 1)
                {
                    //loop through all bullets and decrement the Y-values
                    foreach (var i in this.pictureBoxesLeft)
                    {
                        i.Location = new Point(i.Location.X, i.Location.Y - this.projectileYDecrement);

                        //check if it is a hit
                        if (this.checkFighterHit(i.Location.X, i.Location.Y) == true)
                        {
                            //remove current projectile from projectile list
                            i.Visible = false;
                            this.pictureBoxesLeft.Remove(i);
                        }

                        if (i.Location.Y < (0 - this.projectileSize.Height))
                        {
                            //remove current projectile from projectile list
                            this.pictureBoxesLeft.Remove(i);
                        }
                    }
                }

                if (this.pictureBoxesRight.Count >= 1)
                {
                    //loop through all bullets and decrement the Y-values
                    foreach (var i in this.pictureBoxesRight)
                    {
                        i.Location = new Point(i.Location.X, i.Location.Y - this.projectileYDecrement);

                        //check if it is a hit
                        if (this.checkFighterHit(i.Location.X, i.Location.Y) == true)
                        {
                            //remove current projectile from projectile list
                            i.Visible = false;
                            this.pictureBoxesRight.Remove(i);
                        }

                        if (i.Location.Y < (0 - this.projectileSize.Height))
                        {
                            //remove current projectile from projectile list
                            this.pictureBoxesRight.Remove(i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            //check if there are any bombers left
            if(this.checkAllBomberssHit() == true)
            {
                this.level++;
                this.labelLevel.Text = "Level: " + this.level.ToString();

                //populate new bombers
                this.populateBombers();
            }
        }

        //check if the current bullet is hitting a visible bomber
        private bool checkFighterHit(int bulletXfrom, int bulletYfrom)
        {
            //loop through all bombers, beginning from the bottom row

            for (int i = this.pictureBoxesBombers.Count -1; i >= 0; i--)
            {
                if (bulletXfrom >= pictureBoxesBombers[i].Location.X && bulletXfrom <= pictureBoxesBombers[i].Location.X + pictureBoxesBombers[i].Width && bulletYfrom <= pictureBoxesBombers[i].Location.Y && bulletYfrom <= pictureBoxesBombers[i].Height)
                {
                    this.pictureBoxesBombers[i].Visible = false;
                    this.pictureBoxesBombers.RemoveAt(i);

                    //increase score by 10
                    this.score += 10;
                    this.labelScore.Text = "Score: " + this.score.ToString();
                    
                    return true;
                }
            }

            return false;
        }

        //check if all bombers are hidden
        private bool checkAllBomberssHit ()
        {
            if(this.pictureBoxesBombers.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //populate bomber pictureboxes
        private void populateBombers ()
        {
            //add initial bombers, row wise and column wise
            int noOfColumns = this.Width / 60;
            int inc = 0;

            for (int rowIndex = 0; rowIndex < 4; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < noOfColumns; columnIndex++)
                {
                    this.pictureBoxesBombers.Add(new PictureBox());
                    pictureBoxesBombers[inc].Location = new Point(this.startXbomber + (columnIndex * incrementBomberX), this.startYbomber + (rowIndex * incrementBomberX));
                    pictureBoxesBombers[pictureBoxesBombers.Count - 1].Size = this.bomberSize;
                    pictureBoxesBombers[pictureBoxesBombers.Count - 1].BackColor = this.BackColor;
                    pictureBoxesBombers[pictureBoxesBombers.Count - 1].Image = this.bomberBitmap;
                    pictureBoxesBombers[pictureBoxesBombers.Count - 1].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxesBombers[pictureBoxesBombers.Count - 1].Visible = true;
                    this.Controls.Add(pictureBoxesBombers[pictureBoxesBombers.Count - 1]);

                    inc++;
                }
            }
        }
    }
}