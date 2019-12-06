using System;
using System.Collections.Generic;

namespace GraphicalTestApp
{
    delegate void StartEvent();
    delegate void UpdateEvent(float deltaTime);
    delegate void DrawEvent();

    class Actor
    {
        public StartEvent OnStart;
        public UpdateEvent OnUpdate;
        public DrawEvent OnDraw;

        public bool Started { get; private set; } = false;

        public Actor Parent { get; private set; } = null;
        protected List<Actor> _children = new List<Actor>();
        private List<Actor> _additions = new List<Actor>();
        private List<Actor> _removals = new List<Actor>();

        private Matrix3 _localTransform = new Matrix3();
        private Matrix3 _globalTransform = new Matrix3();

        // The Entity's location on the X axis
        public float X
        {
            //## Implement the relative X coordinate ##//
            // get { return 0; }
            // set { }
            get
            {
                return _localTransform.m1x3;
            }
            set
            {
                _localTransform.SetTranslation(value, Y, 1);
                UpdateTransform();
            }
        }

        public float XAbsolute
        {
            //## Implement the absolute X coordinate ##//
            // get { return 0; }
            get { return _globalTransform.m1x3; }
        }

        // The Entity's location on the Y axis
        public float Y
        {
            //## Implement the relative Y coordinate ##//
            // get { return 0; }
            // set { }
            get
            {
                return _localTransform.m2x3;
            }
            set
            {
                _localTransform.SetTranslation(X, value, 1);
                UpdateTransform();
            }
        }
        public float YAbsolute
        {
            //## Implement the absolute Y coordinate ##//
            // get { return 0; }
            get { return _globalTransform.m2x3; }
        }


        public Vector3 GetDirection()
        {
            return new Vector3(_localTransform.m1x2, _localTransform.m1x1, 0);
        }

        public Vector3 GetDirectionAbsolute()
        {
            return new Vector3(_globalTransform.m1x2, _globalTransform.m1x1, 0);
        }

        public float getM1x1
        {
           get { return _globalTransform.m1x1; }
        }

        public float getM1x2
        {
            get { return _globalTransform.m1x2; }
        }





        public float GetRotationAbsolute()
        {
            //## Implement getting the rotation of _globalTransform ##//
            return (float)Math.Atan2(_globalTransform.m2x1, _globalTransform.m1x1);
        }

        public float GetRotation()
        {
            //## Implement getting the rotation of _localTransform ##//
            return (float)Math.Atan2(_localTransform.m2x1, _localTransform.m1x1);
            // return 0;
        }

        public void Rotate(float radians)
        {
            //## Implement rotating _localTransform ##//
            _localTransform.RotateZ(radians);
            UpdateTransform();
        }

        public float GetScaleAbsolute()
        {
            //## Implement getting the scale of _globalTransform ##//
            return 1;
        }

        public float GetScale()
        {
            //## Implement getting the scale of _localTransform ##//
            // return 0;
            return 1;
        }

        public void Scale(float scale)
        {
            //## Implement scaling _localTransform ##//
            _localTransform.Scale(scale, scale, 1);
            UpdateTransform();
        }

        public void AddChild(Actor child)
        {
            //## Implement AddChild(Actor) ##//
            bool isChild = _children.Contains(child);
            if (!isChild)
            {
                // Adds to the addition waiting queue
                // Add new child to collection
                _additions.Add(child);
                // Assign this Entity as the child's parent
                child.Parent = this;
            }
        }

        public void RemoveChild(Actor child)
        {
            //## Implement RemoveChild(Actor) ##//
            // Checks if child exists in the collection, if so set parent = null then add to removals
            bool isChild = _children.Contains(child);
            if (isChild)
            {
                // Adds to the removal waiting queue
                _removals.Add(child);
                child.Parent = null;
            }
        }

        public void UpdateTransform()
        {
            //## Implment UpdateTransform() ##//
            if(Parent != null)
            {
                _globalTransform = Parent._globalTransform * _localTransform;
            }
            else
            {
                _globalTransform = _localTransform;
            }
            foreach (Actor child in _children)
            {
                child.UpdateTransform();
            }
        }

        // Grabs the m1x1 position
        public float Getm1x1
        {
            get { return _globalTransform.m1x1; }
        }

        // Grabs the m1x2 position
        public float Getm1x2
        {
            get { return _globalTransform.m1x2; }
        }

        //Call the OnStart events of the Actor and its children
        public virtual void Start()
        {
            //Call this Actor's OnStart events
            OnStart?.Invoke();

            //Start all of this Actor's children
            foreach (Actor child in _children)
            {
                child.Start();
            }

            //Flag this Actor as having already started
            Started = true;
        }

        //Call the OnUpdate events of the Actor and its children
        public virtual void Update(float deltaTime)
        {
            //Update this Actor and its children's transforms
            UpdateTransform();

            //Call this Actor's OnUpdate events
            OnUpdate?.Invoke(deltaTime);

            //Add all the Actors readied for addition
            foreach (Actor a in _additions)
            {
                //Add a to _children
                _children.Add(a);
            }
            //Reset the addition list
            _additions.Clear();

            //Remove all the Actors readied for removal
            foreach (Actor a in _removals)
            {
                //Add a to _children
                _children.Remove(a);
            }
            //Reset the removal list
            _removals.Clear();


            //Update all of this Actor's children
            foreach (Actor child in _children)
            {
                child.Update(deltaTime);
            }
        }

        //Call the OnDraw events of the Actor and its children
        public virtual void Draw()
        {
            //Call this Actor's OnDraw events
            OnDraw?.Invoke();

            //Update all of this Actor's children
            foreach (Actor child in _children)
            {
                child.Draw();
            }
        }
    }
}
