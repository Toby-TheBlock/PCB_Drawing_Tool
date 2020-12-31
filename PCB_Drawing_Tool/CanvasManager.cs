﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PCB_Drawing_Tool
{
	class CanvasManager
	{
		private static CanvasManager singleton = null;
		private Dictionary<int, PictureBox> allCanvasGraphics;
		private List<CanvasObject> allCanvasObjects;


		private CanvasManager()
		{
			allCanvasGraphics = new Dictionary<int, PictureBox>();
			allCanvasObjects = new List<CanvasObject>();
		}


		public List<CanvasObject> AllCanvasObjects
		{
			get { return allCanvasObjects; }
		}


		public static CanvasManager Singleton
        {
			get
            {
				if (singleton == null)
                {
					singleton = new CanvasManager();
                }
				return singleton;
            }
        }


		/*
		public void UpdateObject(int id, PictureBox newObject)
		{
			allCanvasGraphics[id] = newObject;
		}
		
		public List<int> GetObjectDetails(int objectID)
		{
			PictureBox picObject = allCanvasGraphics[objectID]; 
			return new List<int>(){ picObject.Location.X, picObject.Location.Y, picObject.Width, picObject.Height, Convert.ToInt32(picObject.Name) };
		}

		public int GetSmallestObjectAspect()
        {
			int smallestValue = 100000;

			foreach(CanvasObject element in allCanvasObjects)
            {
				string[] info = element.GetObjectParameters();
            }

			for (int i = 1; i <= GetCountOfCanvasObjects(); i++)
			{
				List<int> info = GetObjectDetails(i);
				if (info[2] < smallestValue || info[3] < smallestValue)
                {
					if (info[2] < info[3])
                    {
						smallestValue = info[2];
                    }
					else
                    {
						smallestValue = info[3];
                    }
                }
			}
			return smallestValue;
        }
		*/


		/// <summary>
		/// Removes the last CanvasObject be removing it from both the allCanvasObjects and allCanvasGraphics collection.
		/// </summary>
		/// <returns>The corresponding PictureBox which is physically represented on the main Canvas in the Form.</returns>
		public PictureBox RemoveLastObjectFromCanvas()
        {
			if (GetCountOfCanvasObjects() > 0)
            {
				allCanvasObjects.RemoveAt(GetCountOfCanvasObjects() - 1);
				
				PictureBox removedObject = allCanvasGraphics[allCanvasGraphics.Keys.Last()];
				allCanvasGraphics.Remove(allCanvasGraphics.Keys.Last());
				return removedObject;
            } 
			else
            {
				MessageBox.Show("There are no objects that can be removed!");
				return null;
            }
        }


		/// <summary>
		/// Registers the creation of a new CanvasObject, by storing it in the allCanvasObjects and allCanvasGraphics collections.
		/// </summary>
		/// <param name="newObject"></param>
		/// <param name="newGraphic"></param>
		public void AddObject(CanvasObject newObject, PictureBox newGraphic)
        {
			allCanvasGraphics.Add(allCanvasObjects.Count + 1, newGraphic);
			allCanvasObjects.Add(newObject);
		}


		public int GetCountOfCanvasObjects()
		{
			return allCanvasObjects.Count();
		}


		public PictureBox GetCanvasGraphic(int objectID)
		{
			return allCanvasGraphics[objectID];
		}
	}
}

