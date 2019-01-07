using UnityEngine;

namespace Misc
{
	public class MovingPlatform : MonoBehaviour 
	{
		[SerializeField] private Transform[] _wayPoints;
		[SerializeField] private float _speed = 2;
		[SerializeField] private int _currentPoint;

		private void Update () 
		{
			// Check if the platform is in the same position as the way point.
			if(transform.position != _wayPoints[_currentPoint].transform.position)
			{
				// Move the platform towards the way point.
				transform.position = Vector3.MoveTowards(transform.position,
					_wayPoints[_currentPoint].transform.position, _speed * Time.deltaTime);
			}
			// Once the platform goes to the way point, target the next one.
			else
			{
				// Target the first way point if you get to the end of the list.
				if( _currentPoint >= _wayPoints.Length)
				{
					_currentPoint = 0; 
				}
				else
				{
					_currentPoint += 1;
				}
			}
		}
	}
}