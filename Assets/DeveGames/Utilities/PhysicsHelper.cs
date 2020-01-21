using UnityEngine;

namespace DeveGames.Utilities
{
    public static class PhysicsHelper
    {
        public static Vector3[] GetBoxColliderVertexPoints(BoxCollider boxCollider)
        {
            var vertices = new Vector3[8];
            var size = boxCollider.size;
            vertices[0] = boxCollider.transform.TransformPoint(boxCollider.center + new Vector3(-size.x, -size.y, -size.z) * 0.5f);
            vertices[1] = boxCollider.transform.TransformPoint(boxCollider.center + new Vector3(size.x, -size.y, -size.z) * 0.5f);
            vertices[2] = boxCollider.transform.TransformPoint(boxCollider.center + new Vector3(size.x, -size.y, size.z) * 0.5f);
            vertices[3] = boxCollider.transform.TransformPoint(boxCollider.center + new Vector3(-size.x, -size.y, size.z) * 0.5f);
            vertices[4] = boxCollider.transform.TransformPoint(boxCollider.center + new Vector3(-size.x, size.y, -size.z) * 0.5f);
            vertices[5] = boxCollider.transform.TransformPoint(boxCollider.center + new Vector3(size.x, size.y, -size.z) * 0.5f);
            vertices[6] = boxCollider.transform.TransformPoint(boxCollider.center + new Vector3(size.x, size.y, size.z) * 0.5f);
            vertices[7] = boxCollider.transform.TransformPoint(boxCollider.center + new Vector3(-size.x, size.y, size.z) * 0.5f);
            return vertices;
        }

        public static Vector2[] GetTrajectoryPoints(Vector2 startPosition, Vector2 velocity, int stepCount, float timeBetweenSteps)
        {
            Vector2[] trajectoryPoints = new Vector2[stepCount];

            for (int i = 0; i < stepCount; i++)
            {
                var time = i * timeBetweenSteps;
                trajectoryPoints[i].x = startPosition.x + velocity.x * time;
                trajectoryPoints[i].y = startPosition.y +  (velocity.y * time) - (0.5f * (-1f * Physics.gravity.y) * time * time);
            }
            
            return trajectoryPoints;
        }

        public static Vector3 GetTravelVelocity(Vector3 startPoint, Vector3 endPoint, float degree)
        {
            float gravity = Physics.gravity.magnitude;
            float angle = degree * Mathf.Deg2Rad;
            float distance = Vector3.Distance(startPoint, endPoint);
            float yOffset = startPoint.y - endPoint.y;
            float initialVelocity = (1f / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
            
            Vector3 velocity = new Vector3(0f, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));
            float angleBetweenObjects = MathfHelper.Angle(Vector3.forward, endPoint - startPoint) * (endPoint.x > startPoint.x ? 1f : -1f);

            return Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;
        }

        public static Vector2[] Plot(Rigidbody2D rigidbody, Vector2 position, Vector2 velocity, int steps)
        {
            Vector2[] results = new Vector2[steps];
 
            float timeStep = Time.fixedDeltaTime / Physics2D.velocityIterations;
            Vector2 gravityAcceleration = timeStep * rigidbody.gravityScale * timeStep * Physics2D.gravity;
            float drag = 1f - timeStep * rigidbody.drag;
            Vector2 moveStep = velocity * timeStep;
 
            for (int i = 0; i < steps; ++i)
            {
                moveStep += gravityAcceleration;
                moveStep *= drag;
                position += moveStep;
                results[i] = position;
            }
 
            return results;
        }
    }
}