using System;
using Tao.OpenGl;
using Platform.Windows;

namespace MyProject_2CPR1
{
	
	public class MainClass
	{

		protected bool running=true;

		protected int Width=1024;
		protected int Height=768;

		protected Glut.PassiveMotionCallback PassiveMotionFunc = null;
		protected Avatar observer;
		public MainClass(string[] args) 
		{
			GlControl ViewPort = new GlControl(Width,Height);
			GlObjectList world = new GlObjectList();
			world.Add(new LightSource());//ຄວາມສະຫວ່າງຂອງແສງ

			world.Add(new TranslatedObject(new Point3D(0,-10,0),new SkyBox()));//ແສງທັງໝົດ
			GlObjectList CPR1 = new GlObjectList();
			CPR1.Add(new CPR1());//ບ້ານ

			GlObject c = new TranslatedObject(new Point3D(0,0,-70), CPR1);//ຄວາມໄວ້ຂອງການຍາງ
			world.Add(c);


			observer=new Avatar(ViewPort, world);
			Glut.glutDisplayFunc(new Glut.DisplayCallback(observer.Look));
			Glut.glutIdleFunc(new Glut.IdleCallback(observer.Look)); 
			Glut.glutMainLoop();
		}

		public static void Main(string[] args) 
		{
			new MainClass(args);
		}
	}




}



