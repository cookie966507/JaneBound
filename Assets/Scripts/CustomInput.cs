using UnityEngine;
using System.Collections;

/*
 * Author: Jonathan Hunter
 */

namespace Assets.Scripts
{
    public class CustomInput : MonoBehaviour
    {
        public const string LEFT_STICK_RIGHT = "Left Stick Right";
        public const string LEFT_STICK_LEFT = "Left Stick Left";
        public const string LEFT_STICK_UP = "Left Stick Up";
        public const string LEFT_STICK_DOWN = "Left Stick Down";
        public const string RIGHT_STICK_RIGHT = "Right Stick Right";
        public const string RIGHT_STICK_LEFT = "Right Stick Left";
        public const string RIGHT_STICK_UP = "Right Stick Up";
        public const string RIGHT_STICK_DOWN = "Right Stick Down";
        public const string DPAD_RIGHT = "Dpad Right";
        public const string DPAD_LEFT = "Dpad Left";
        public const string DPAD_UP = "Dpad Up";
        public const string DPAD_DOWN = "Dpad Down";
        public const string LEFT_TRIGGER = "Left Trigger";
        public const string RIGHT_TRIGGER = "Right Trigger";
        public const string A = "A";
        public const string B = "B";
        public const string X = "X";
        public const string Y = "Y";
        public const string LB = "LB";
        public const string RB = "RB";
        public const string BACK = "Back";
        public const string START = "Start";
        public const string LEFT_STICK = "Left Stick Click";
        public const string RIGHT_STICK = "Right Stick Click";

        private const int BLOW = 0x1;
        private const int SHOOT = 0x2;
        private const int JUMP = 0x4;
		private const int LEFT = 0x8;
		private const int RIGHT = 0x10;
		private const int SNEAK = 0x20;
		private const int UP = 0x40;
		private const int DOWN = 0x80;
		private const int SUPER = 0x100;

		private const int ACCEPT = 0x200;
		private const int CANCEL = 0x400;
		private const int PAUSE = 0x800;

        private static int bools = 0;
        private static int boolsUp = 0;
        private static int boolsHeld = 0;
        private static int boolsFreshPress = 0;
        private static int boolsFreshPressAccessed = 0;
        private static int boolsFreshPressDeleteOnRead = 0;



        //true as long as the button is held
        public static bool Blow
        {
            get { return (bools & BLOW) != 0; }
        }
        public static bool Jump
        {
            get { return (bools & JUMP) != 0; }
        }
        public static bool Left
        {
            get { return (bools & LEFT) != 0; }
        }
        public static bool Right
        {
            get { return (bools & RIGHT) != 0; }
        }
        public static bool Shoot
        {
            get { return (bools & SHOOT) != 0; }
        }
        public static bool Sneak
        {
            get { return (bools & SNEAK) != 0; }
        }
        public static bool Up
        {
            get { return (bools & UP) != 0; }
        }
        public static bool Down
        {
            get { return (bools & DOWN) != 0; }
        }
        public static bool Super
        {
            get { return (bools & SUPER) != 0; }
        }
        public static bool Accept
        {
            get { return (bools & ACCEPT) != 0; }
        }
        public static bool Cancel
        {
            get { return (bools & CANCEL) != 0; }
        }
        public static bool Pause
        {
            get { return (bools & PAUSE) != 0; }
        }

        //true for one frame after button is let go.
        public static bool BlowUp
        {
            get { return (boolsUp & BLOW) != 0; }
        }
        public static bool JumpUp
        {
            get { return (boolsUp & JUMP) != 0; }
        }
        public static bool LeftUp
        {
            get { return (boolsUp & LEFT) != 0; }
        }
        public static bool RightUp
        {
            get { return (boolsUp & RIGHT) != 0; }
        }
        public static bool ShootUp
        {
            get { return (boolsUp & SHOOT) != 0; }
        }
        public static bool SneakUp
        {
            get { return (boolsUp & SNEAK) != 0; }
        }
        public static bool UpUp
        {
            get { return (boolsUp & UP) != 0; }
        }
        public static bool DownUp
        {
            get { return (boolsUp & DOWN) != 0; }
        }
        public static bool SuperUp
        {
            get { return (boolsUp & SUPER) != 0; }
        }
        public static bool AcceptUp
        {
            get { return (boolsUp & ACCEPT) != 0; }
        }
        public static bool CancelUp
        {
            get { return (boolsUp & CANCEL) != 0; }
        }
        public static bool PauseUp
        {
            get { return (boolsUp & PAUSE) != 0; }
        }

        //true until the button is let go.
        public static bool BlowHeld
        {
            get { return (boolsHeld & BLOW) != 0; }
        }
        public static bool JumpHeld
        {
            get { return (boolsHeld & JUMP) != 0; }
        }
        public static bool LeftHeld
        {
            get { return (boolsHeld & LEFT) != 0; }
        }
        public static bool RightHeld
        {
            get { return (boolsHeld & RIGHT) != 0; }
        }
        public static bool ShootHeld
        {
            get { return (boolsHeld & SHOOT) != 0; }
        }
        public static bool SneakHeld
        {
            get { return (boolsHeld & SNEAK) != 0; }
        }
        public static bool UpHeld
        {
            get { return (boolsHeld & UP) != 0; }
        }
        public static bool DownHeld
        {
            get { return (boolsHeld & DOWN) != 0; }
        }
        public static bool SuperHeld
        {
            get { return (boolsHeld & SUPER) != 0; }
        }
        public static bool AcceptHeld
        {
            get { return (boolsHeld & ACCEPT) != 0; }
        }
        public static bool CancelHeld
        {
            get { return (boolsHeld & CANCEL) != 0; }
        }
        public static bool PauseHeld
        {
            get { return (boolsHeld & PAUSE) != 0; }
        }

        //true as until the data is read or the key is released
        public static bool BlowFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | BLOW;
                return (boolsFreshPress & BLOW) != 0;
            }
        }
        public static bool JumpFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | JUMP;
                return (boolsFreshPress & JUMP) != 0;
            }
        }
        public static bool LeftFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | LEFT;
                return (boolsFreshPress & LEFT) != 0;
            }
        }
        public static bool RightFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | RIGHT;
                return (boolsFreshPress & RIGHT) != 0;
            }
        }
        public static bool ShootFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | SHOOT;
                return (boolsFreshPress & SHOOT) != 0;
            }
        }
        public static bool SneakFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | SNEAK;
                return (boolsFreshPress & SNEAK) != 0;
            }
        }
        public static bool UpFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | UP;
                return (boolsFreshPress & UP) != 0;
            }
        }
        public static bool DownFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | DOWN;
                return (boolsFreshPress & DOWN) != 0;
            }
        }
        public static bool SuperFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | SUPER;
                return (boolsFreshPress & SUPER) != 0;
            }
        }
        public static bool AcceptFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | ACCEPT;
                return (boolsFreshPress & ACCEPT) != 0;
            }
        }
        public static bool CancelFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | CANCEL;
                return (boolsFreshPress & CANCEL) != 0;
            }
        }
        public static bool PauseFreshPress
        {
            get
            {
                boolsFreshPressAccessed = boolsFreshPressAccessed | PAUSE;
                return (boolsFreshPress & PAUSE) != 0;
            }
        }

        //true as until the data is read or the key is released
        public static bool BlowFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & BLOW) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~BLOW;
                return temp;
            }
        }
        public static bool JumpFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & JUMP) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~JUMP;
                return temp;
            }
        }
        public static bool LeftFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & LEFT) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~LEFT;
                return temp;
            }
        }
        public static bool RightFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & RIGHT) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~RIGHT;
                return temp;
            }
        }
        public static bool ShootFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & SHOOT) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~SHOOT;
                return temp;
            }
        }
        public static bool SneakFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & SNEAK) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~SNEAK;
                return temp;
            }
        }
        public static bool UpFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & UP) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~UP;
                return temp;
            }
        }
        public static bool DownFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & DOWN) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~DOWN;
                return temp;
            }
        }
        public static bool SuperFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & SUPER) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~SUPER;
                return temp;
            }
        }
        public static bool AcceptFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & ACCEPT) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~ACCEPT;
                return temp;
            }
        }
        public static bool CancelFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & CANCEL) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~CANCEL;
                return temp;
            }
        }
        public static bool PauseFreshPressDeleteOnRead
        {
            get
            {
                bool temp = (boolsFreshPressDeleteOnRead & PAUSE) != 0;
                boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~PAUSE;
                return temp;
            }
        }

        private static KeyCode keyBoardBlow;
        private static KeyCode keyBoardJump;
        private static KeyCode keyBoardLeft;
        private static KeyCode keyBoardRight;
        private static KeyCode keyBoardShoot;
        private static KeyCode keyBoardSneak;
        private static KeyCode keyBoardUp;
        private static KeyCode keyBoardDown;
        private static KeyCode keyBoardSuper;
        private static KeyCode keyBoardAccept;
        private static KeyCode keyBoardCancel;
        private static KeyCode keyBoardPause;

        private static string gamePadBlow;
        private static string gamePadJump;
        private static string gamePadLeft;
        private static string gamePadRight;
        private static string gamePadShoot;
        private static string gamePadSneak;
        private static string gamePadUp;
        private static string gamePadDown;
        private static string gamePadSuper;
        private static string gamePadAccept;
        private static string gamePadCancel;
        private static string gamePadPause;

        private static string KeyHash = "JaneBoundKeys";

        private static bool usePad = false;

        public static bool UsePad
        {
            get { return usePad; }
        }

        public static KeyCode KeyBoardBlow
        {
            get { return keyBoardBlow; }
            set
            {
                keyBoardBlow = value;
                PlayerPrefs.SetInt(0 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardJump
        {
            get { return keyBoardJump; }
            set
            {
                keyBoardJump = value;
                PlayerPrefs.SetInt(1 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardLeft
        {
            get { return keyBoardLeft; }
            set
            {
                keyBoardLeft = value;
                PlayerPrefs.SetInt(4 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardRight
        {
            get { return keyBoardRight; }
            set
            {
                keyBoardRight = value;
                PlayerPrefs.SetInt(5 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardShoot
        {
            get { return keyBoardShoot; }
            set
            {
                keyBoardShoot = value;
                PlayerPrefs.SetInt(6 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardSneak
        {
            get { return keyBoardSneak; }
            set
            {
                keyBoardSneak = value;
                PlayerPrefs.SetInt(7 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardUp
        {
            get { return keyBoardUp; }
            set
            {
                keyBoardUp = value;
                PlayerPrefs.SetInt(8 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardDown
        {
            get { return keyBoardDown; }
            set
            {
                keyBoardDown = value;
                PlayerPrefs.SetInt(9 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardSuper
        {
            get { return keyBoardSuper; }
            set
            {
                keyBoardSuper = value;
                PlayerPrefs.SetInt(10 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardAccept
        {
            get { return keyBoardAccept; }
            set
            {
                keyBoardAccept = value;
                PlayerPrefs.SetInt(11 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardCancel
        {
            get { return keyBoardCancel; }
            set
            {
                keyBoardCancel = value;
                PlayerPrefs.SetInt(12 + KeyHash, (int)value);
            }
        }
        public static KeyCode KeyBoardPause
        {
            get { return keyBoardPause; }
            set
            {
                keyBoardPause = value;
                PlayerPrefs.SetInt(13 + KeyHash, (int)value);
            }
        }
        public static string GamePadBlow
        {
            get { return gamePadBlow; }
            set
            {
                gamePadBlow = value;
                PlayerPrefs.SetString(14 + KeyHash, value);
            }
        }
        public static string GamePadJump
        {
            get { return gamePadJump; }
            set
            {
                gamePadJump = value;
                PlayerPrefs.SetString(15 + KeyHash, value);
            }
        }
        public static string GamePadLeft
        {
            get { return gamePadLeft; }
            set
            {
                gamePadLeft = value;
                PlayerPrefs.SetString(18 + KeyHash, value);
            }
        }
        public static string GamePadRight
        {
            get { return gamePadRight; }
            set
            {
                gamePadRight = value;
                PlayerPrefs.SetString(19 + KeyHash, value);
            }
        }
        public static string GamePadShoot
        {
            get { return gamePadShoot; }
            set
            {
                gamePadShoot = value;
                PlayerPrefs.SetString(20 + KeyHash, value);
            }
        }
        public static string GamePadSneak
        {
            get { return gamePadSneak; }
            set
            {
                gamePadSneak = value;
                PlayerPrefs.SetString(21 + KeyHash, value);
            }
        }
        public static string GamePadUp
        {
            get { return gamePadUp; }
            set
            {
                gamePadUp = value;
                PlayerPrefs.SetString(22 + KeyHash, value);
            }
        }
        public static string GamePadDown
        {
            get { return gamePadDown; }
            set
            {
                gamePadDown = value;
                PlayerPrefs.SetString(23 + KeyHash, value);
            }
        }
        public static string GamePadSuper
        {
            get { return gamePadSuper; }
            set
            {
                gamePadSuper = value;
                PlayerPrefs.SetString(24 + KeyHash, value);
            }
        }
        public static string GamePadAccept
        {
            get { return gamePadAccept; }
            set
            {
                gamePadAccept = value;
                PlayerPrefs.SetString(25 + KeyHash, value);
            }
        }
        public static string GamePadCancel
        {
            get { return gamePadCancel; }
            set
            {
                gamePadCancel = value;
                PlayerPrefs.SetString(26 + KeyHash, value);
            }
        }
        public static string GamePadPause
        {
            get { return gamePadPause; }
            set
            {
                gamePadPause = value;
                PlayerPrefs.SetString(27 + KeyHash, value);
            }
        }

        void Awake()
        {
            bools = 0;
            boolsUp = 0;
            boolsHeld = 0;
            boolsFreshPress = 0;
            boolsFreshPressAccessed = 0;
            boolsFreshPressDeleteOnRead = 0;
            if (PlayerPrefs.HasKey(0 + KeyHash))
            {
                keyBoardBlow = (KeyCode)PlayerPrefs.GetInt(0 + KeyHash);
                keyBoardJump = (KeyCode)PlayerPrefs.GetInt(1 + KeyHash);
                keyBoardLeft = (KeyCode)PlayerPrefs.GetInt(2 + KeyHash);
                keyBoardRight = (KeyCode)PlayerPrefs.GetInt(3 + KeyHash);
                keyBoardShoot = (KeyCode)PlayerPrefs.GetInt(4 + KeyHash);
                keyBoardSneak = (KeyCode)PlayerPrefs.GetInt(5 + KeyHash);
                keyBoardUp = (KeyCode)PlayerPrefs.GetInt(6 + KeyHash);
                keyBoardDown = (KeyCode)PlayerPrefs.GetInt(7 + KeyHash);
                keyBoardSuper = (KeyCode)PlayerPrefs.GetInt(8 + KeyHash);
                keyBoardAccept = (KeyCode)PlayerPrefs.GetInt(9 + KeyHash);
                keyBoardCancel = (KeyCode)PlayerPrefs.GetInt(10 + KeyHash);
                keyBoardPause = (KeyCode)PlayerPrefs.GetInt(11 + KeyHash);

                gamePadBlow = PlayerPrefs.GetString(12 + KeyHash);
                gamePadJump = PlayerPrefs.GetString(13 + KeyHash);
                gamePadLeft = PlayerPrefs.GetString(14 + KeyHash);
                gamePadRight = PlayerPrefs.GetString(15 + KeyHash);
                gamePadShoot = PlayerPrefs.GetString(16 + KeyHash);
                gamePadSneak = PlayerPrefs.GetString(17 + KeyHash);
                gamePadUp = PlayerPrefs.GetString(18 + KeyHash);
                gamePadDown = PlayerPrefs.GetString(19 + KeyHash);
                gamePadSuper = PlayerPrefs.GetString(20 + KeyHash);
                gamePadAccept = PlayerPrefs.GetString(21 + KeyHash);
                gamePadCancel = PlayerPrefs.GetString(22 + KeyHash);
                gamePadPause = PlayerPrefs.GetString(23 + KeyHash);
            }
            else
                Default();
        }
        void Update()
        {
            if (Input.anyKey)
                usePad = false;
            if (AnyPadInput())
                usePad = true;
            if (!usePad)
            {
                updateKey(BLOW, keyBoardBlow);
                updateKey(JUMP, keyBoardJump);
                updateKey(LEFT, keyBoardLeft, KeyCode.LeftArrow);
                updateKey(RIGHT, keyBoardRight, KeyCode.RightArrow);
                updateKey(SHOOT, keyBoardShoot);
                updateKey(SNEAK, keyBoardSneak);
                updateKey(UP, keyBoardUp, KeyCode.UpArrow);
                updateKey(DOWN, keyBoardDown, KeyCode.DownArrow);
                updateKey(SUPER, keyBoardSuper);
                updateKey(ACCEPT, keyBoardAccept);
                updateKey(CANCEL, keyBoardCancel);
                updateKey(PAUSE, keyBoardPause);
            }
            else
            {
                updatePad(BLOW, gamePadBlow);
                updatePad(JUMP, gamePadJump);
                updatePad(LEFT, gamePadLeft);
                updatePad(RIGHT, gamePadRight);
                updatePad(SHOOT, gamePadShoot);
                updatePad(SNEAK, gamePadSneak);
                updatePad(UP, gamePadUp);
                updatePad(DOWN, gamePadDown);
                updatePad(SUPER, gamePadSuper);
                updatePad(ACCEPT, gamePadAccept);
                updatePad(CANCEL, gamePadCancel);
                updatePad(PAUSE, gamePadPause);
            }
        }
        private static void updateKey(int state, params KeyCode[] keys)
        {
            bool key = false, keyUp = false;
            foreach (KeyCode k in keys)
            {
                if (Input.GetKeyDown(k))
                    key = true;
                else if (Input.GetKeyUp(k))
                    keyUp = true;
            }
            if ((boolsFreshPressAccessed & state) != 0)
            {
                boolsFreshPressAccessed = (boolsFreshPressAccessed & ~state);
                boolsFreshPress = (boolsFreshPress & ~state);
                boolsFreshPressDeleteOnRead = (boolsFreshPressDeleteOnRead & ~state);
            }
            if (((bools & state) == 0) && key)
            {
                boolsFreshPress = boolsFreshPress | state;
                boolsFreshPressDeleteOnRead = (boolsFreshPressDeleteOnRead | state);
            }
            if (key)
            {
                bools = bools | state;
                boolsHeld = boolsHeld | state;
                boolsUp = boolsUp & ~state;
            }
            else if (keyUp)
            {
                bools = bools & ~state;
                boolsHeld = boolsHeld & ~state;
                boolsFreshPress = boolsFreshPress & ~state;
                boolsFreshPressDeleteOnRead = (boolsFreshPressDeleteOnRead & ~state);
                boolsFreshPressAccessed = (boolsFreshPressAccessed & ~state);
                boolsUp = boolsUp | state;
            }
            else
                boolsUp = boolsUp & ~state;
        }
        private static void updatePad(int state, string axes)
        {
            float input = Input.GetAxis(axes);
            bool key = false, keyUp = false;
            if (axes == LEFT_STICK_LEFT || axes == LEFT_STICK_UP || axes == RIGHT_STICK_LEFT || axes == RIGHT_STICK_UP || axes == DPAD_LEFT || axes == DPAD_DOWN || axes == RIGHT_TRIGGER)
            {
                if (input < 0)
                    key = true;
                else if ((bools & state) != 0)
                    keyUp = true;
            }
            else if (input > 0)
                key = true;
            else if ((bools & state) != 0)
                keyUp = true;

            if ((boolsFreshPressAccessed & state) != 0)
            {
                boolsFreshPressAccessed = (boolsFreshPressAccessed & ~state);
                boolsFreshPress = (boolsFreshPress & ~state);
                boolsFreshPressDeleteOnRead = (boolsFreshPressDeleteOnRead & ~state);
            }
            if (((bools & state) == 0) && key)
            {
                boolsFreshPress = boolsFreshPress | state;
                boolsFreshPressDeleteOnRead = (boolsFreshPressDeleteOnRead | state);
            }
            if (key)
            {
                bools = bools | state;
                boolsHeld = boolsHeld | state;
                boolsUp = boolsUp & ~state;
            }
            else if (keyUp)
            {
                bools = bools & ~state;
                boolsHeld = boolsHeld & ~state;
                boolsFreshPress = boolsFreshPress & ~state;
                boolsFreshPressDeleteOnRead = (boolsFreshPressDeleteOnRead & ~state);
                boolsUp = boolsUp | state;
                boolsFreshPressAccessed = (boolsFreshPressAccessed & ~state);
            }
            else
                boolsUp = boolsUp & ~state;
        }

        public static void Default()
        {
            DefaultKey();
            DefaultPad();
        }

        public static void DefaultKey()
        {
            keyBoardBlow = KeyCode.K;
            PlayerPrefs.SetInt(0 + KeyHash, (int)KeyCode.K);
            keyBoardJump = KeyCode.Space;
            PlayerPrefs.SetInt(1 + KeyHash, (int)KeyCode.Space);
            keyBoardLeft = KeyCode.A;
            PlayerPrefs.SetInt(2 + KeyHash, (int)KeyCode.A);
            keyBoardRight = KeyCode.D;
            PlayerPrefs.SetInt(3 + KeyHash, (int)KeyCode.D);
            keyBoardShoot = KeyCode.L;
            PlayerPrefs.SetInt(4 + KeyHash, (int)KeyCode.L);
            keyBoardSneak = KeyCode.Return;
            PlayerPrefs.SetInt(5 + KeyHash, (int)KeyCode.Return);
            keyBoardUp = KeyCode.W;
            PlayerPrefs.SetInt(6 + KeyHash, (int)KeyCode.W);
            keyBoardDown = KeyCode.S;
            PlayerPrefs.SetInt(7 + KeyHash, (int)KeyCode.S);
            keyBoardSuper = KeyCode.J;
            PlayerPrefs.SetInt(8 + KeyHash, (int)KeyCode.J);
            keyBoardAccept = KeyCode.Return;
            PlayerPrefs.SetInt(9 + KeyHash, (int)KeyCode.Return);
            keyBoardCancel = KeyCode.Backspace;
            PlayerPrefs.SetInt(10 + KeyHash, (int)KeyCode.Backspace);
            keyBoardPause = KeyCode.Backspace;
            PlayerPrefs.SetInt(11 + KeyHash, (int)KeyCode.Backspace);
        }

        public static void DefaultPad()
        {
            gamePadBlow = RIGHT_TRIGGER;
            PlayerPrefs.SetString(12 + KeyHash, RIGHT_TRIGGER);
            gamePadJump = A;
            PlayerPrefs.SetString(13 + KeyHash, A);
            gamePadLeft = LEFT_STICK_LEFT;
            PlayerPrefs.SetString(14 + KeyHash, LEFT_STICK_LEFT);
            gamePadRight = LEFT_STICK_RIGHT;
            PlayerPrefs.SetString(15 + KeyHash, LEFT_STICK_RIGHT);
            gamePadShoot = LEFT_TRIGGER;
            PlayerPrefs.SetString(16 + KeyHash, LEFT_TRIGGER);
            gamePadSneak = Y;
            PlayerPrefs.SetString(17 + KeyHash, Y);
            gamePadUp = LEFT_STICK_UP;
            PlayerPrefs.SetString(18 + KeyHash, LEFT_STICK_UP);
            gamePadDown = LEFT_STICK_DOWN;
            PlayerPrefs.SetString(19 + KeyHash, LEFT_STICK_DOWN);
            gamePadSuper = LEFT_STICK;
            PlayerPrefs.SetString(20 + KeyHash, LEFT_STICK);
            gamePadAccept = A;
            PlayerPrefs.SetString(21 + KeyHash, A);
            gamePadCancel = B;
            PlayerPrefs.SetString(22 + KeyHash, B);
            gamePadPause = START;
            PlayerPrefs.SetString(23 + KeyHash, START);
        }

        public static bool AnyInput()
        {
            return bools != 0 || boolsFreshPress != 0 || boolsHeld != 0 || boolsUp != 0;
        }

        public static bool AnyPadInput()
        {
            if (Input.GetAxis(LEFT_STICK_RIGHT) != 0)
                return true;
            if (Input.GetAxis(LEFT_STICK_UP) != 0)
                return true;
            if (Input.GetAxis(RIGHT_STICK_RIGHT) != 0)
                return true;
            if (Input.GetAxis(RIGHT_STICK_UP) != 0)
                return true;
            if (Input.GetAxis(DPAD_RIGHT) != 0)
                return true;
            if (Input.GetAxis(DPAD_UP) != 0)
                return true;
            if (Input.GetAxis(LEFT_TRIGGER) != 0)
                return true;
            if (Input.GetAxis(RIGHT_TRIGGER) != 0)
                return true;
            if (Input.GetAxis(A) != 0)
                return true;
            if (Input.GetAxis(B) != 0)
                return true;
            if (Input.GetAxis(X) != 0)
                return true;
            if (Input.GetAxis(Y) != 0)
                return true;
            if (Input.GetAxis(LB) != 0)
                return true;
            if (Input.GetAxis(RB) != 0)
                return true;
            if (Input.GetAxis(BACK) != 0)
                return true;
            if (Input.GetAxis(START) != 0)
                return true;
            if (Input.GetAxis(LEFT_STICK) != 0)
                return true;
            if (Input.GetAxis(RIGHT_STICK) != 0)
                return true;
            return false;
        }

        public static void UpdatePause()
        {
            bools = bools | PAUSE;
            boolsHeld = boolsHeld & ~PAUSE;
            boolsUp = boolsUp & ~PAUSE;
            boolsFreshPress = boolsFreshPress & ~PAUSE;
            boolsFreshPressAccessed = boolsFreshPressAccessed & ~PAUSE;
            boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~PAUSE;
        }

		public static void UpdateSneak()
		{
			bools = bools | SNEAK;
			boolsHeld = boolsHeld & ~SNEAK;
			boolsUp = boolsUp & ~SNEAK;
			boolsFreshPress = boolsFreshPress & ~SNEAK;
			boolsFreshPressAccessed = boolsFreshPressAccessed & ~SNEAK;
			boolsFreshPressDeleteOnRead = boolsFreshPressDeleteOnRead & ~SNEAK;
		}

        public static string GetText(string input)
        {
            string[] arr = input.Split(' ');
            if (arr[arr.Length - 1] != "<Input>")
                return input;
            switch (arr[0])
            {
                case "Blow": return usePad ? GamePadBlow : KeyBoardBlow.ToString();
                case "Jump": return usePad ? GamePadJump : KeyBoardJump.ToString();
                case "Left": return usePad ? GamePadLeft : KeyBoardLeft.ToString() + " / Left Arrow";
                case "Right": return usePad ? GamePadRight : KeyBoardRight.ToString() + " / Right Arrow";
                case "Shoot": return usePad ? GamePadShoot : KeyBoardShoot.ToString();
                case "Sneak": return usePad ? GamePadSneak : KeyBoardSneak.ToString();
                case "Up": return usePad ? GamePadUp : KeyBoardUp.ToString() + " / Up Arrow";
                case "Down": return usePad ? GamePadDown : KeyBoardDown.ToString() + " / Down Arrow";
                case "Super": return usePad ? GamePadSuper : KeyBoardSuper.ToString();
                case "Accept": return usePad ? GamePadAccept : KeyBoardAccept.ToString();
                case "Cancel": return usePad ? GamePadCancel : KeyBoardCancel.ToString();
                case "Pause": return usePad ? GamePadPause : KeyBoardPause.ToString();
                default: return "invalid input";
            }
        }
    }
}