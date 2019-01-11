using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

namespace Network
{
	public class RoomListItem : MonoBehaviour {

		public delegate void JoinRoomDelegate(MatchInfoSnapshot _match);
		private JoinRoomDelegate _joinRoomCallback;

		[SerializeField]
		private Text _roomNameText;

		private MatchInfoSnapshot _match;

		// This will setup how many players are in the game so far and the room name.
		public void Setup(MatchInfoSnapshot _match, JoinRoomDelegate _joinRoomCallback)
		{
			this._match = _match;
			this._joinRoomCallback = _joinRoomCallback;

			_roomNameText.text = this._match.name + " (" + this._match.currentSize + "/" + this._match.maxSize + ")";

		}

		// This will make the player join the room.
		public void JoinRoom()
		{
			_joinRoomCallback.Invoke(_match);
		}

	}
}
