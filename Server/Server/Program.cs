using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Protocol;
using Google.Protobuf.WellKnownTypes;
using Server.Data;
using Server.Game;
using ServerCore;

namespace Server
{
    class Program
	{
		static Listener _listener = new Listener();
		static List<System.Timers.Timer> _timers = new List<System.Timers.Timer>();

		// Update를 실행시켜주는 함수 System.Timers.Timer를 이용해 tick마다 실행
		static void TickRoom(GameRoom room, int tick = 100)
		{
			var timer = new System.Timers.Timer();
			timer.Interval = tick;
			timer.Elapsed += (s, e) => { room.Update(); };
			timer.AutoReset = true;
			timer.Enabled = true;

			// 나중에 실행중인 타이머를 관리할 수 있게 저장시킴
			_timers.Add(timer);
		}

		static void Main(string[] args)
		{
			ConfigManager.LoadConfig();
			DataManager.LoadData();

			GameRoom gameRoom= RoomManager.Instance.Add(1);
            TickRoom(gameRoom, 10);

			// DNS (Domain Name System)
			//string host = Dns.GetHostName();
			//IPHostEntry ipHost = Dns.GetHostEntry(host);
			IPAddress ipAddr = new IPAddress(new byte[] { 172, 31, 34, 105 });
			IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);	

			_listener.Init(endPoint, () => { return SessionManager.Instance.Generate(); });
			Console.WriteLine("Listening...");

			//FlushRoom();
			//JobTimer.Instance.Push(FlushRoom);

			// TODO
			while (true)
			{
				//JobTimer.Instance.Flush();
				Thread.Sleep(100);
			}
		}
	}
}
