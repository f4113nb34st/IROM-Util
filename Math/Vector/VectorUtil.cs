﻿namespace IROM.Util
{
	using System;
	
	/// <summary>
	/// Defines a variety of utility methods for vectors.
	/// </summary>
	public static class VectorUtil
	{
		/// <summary>
		/// Returns a random Vec2D with each component between 0.0 and 1.0.
		/// </summary>
		/// <returns>A Vec2D with each component greater than or equal to 0.0, and less than 1.0.</returns>
		public static Vec2D Next2D(this Random rand)
		{
			return new Vec2D(rand.NextDouble(), rand.NextDouble());
		}
		
		/// <summary>
		/// Returns a random Vec3D with each component between 0.0 and 1.0.
		/// </summary>
		/// <returns>A Vec3D with each component greater than or equal to 0.0, and less than 1.0.</returns>
		public static Vec3D Next3D(this Random rand)
		{
			return new Vec3D(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
		}
		
		/// <summary>
		/// Returns a random Vec4D with each component between 0.0 and 1.0.
		/// </summary>
		/// <returns>A Vec4D with each component greater than or equal to 0.0, and less than 1.0.</returns>
		public static Vec4D Next4D(this Random rand)
		{
			return new Vec4D(rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
		}
		
		/// <summary>
		/// Returns a random Vec2D with each component between 0.0 and 1.0.
		/// </summary>
		/// <returns>A Vec2D with each component greater than or equal to 0.0, and less than 1.0.</returns>
		public static Vec2D Next2D(this RNG rand)
		{
			return new Vec2D(rand.NextDouble(), rand.NextDouble());
		}
		
		/// <summary>
		/// Returns a random Vec3D with each component between 0.0 and 1.0.
		/// </summary>
		/// <returns>A Vec3D with each component greater than or equal to 0.0, and less than 1.0.</returns>
		public static Vec3D Next3D(this RNG rand)
		{
			return new Vec3D(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
		}
		
		/// <summary>
		/// Returns a random Vec4D with each component between 0.0 and 1.0.
		/// </summary>
		/// <returns>A Vec4D with each component greater than or equal to 0.0, and less than 1.0.</returns>
		public static Vec4D Next4D(this RNG rand)
		{
			return new Vec4D(rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
		}
		
		/// <summary>
		/// Returns the dimension of this array.
		/// </summary>
		/// <param name="array">The array.</param>
		/// <returns>The dimensions.</returns>
		public static Point2D GetDimensions<T>(this T[,] array)
		{
			return new Point2D(array.GetLength(0), array.GetLength(1));
		}
		
		/// <summary>
		/// Returns the dimension of this array.
		/// </summary>
		/// <param name="array">The array.</param>
		/// <returns>The dimensions.</returns>
		public static Point3D GetDimensions<T>(this T[,,] array)
		{
			return new Point3D(array.GetLength(0), array.GetLength(1), array.GetLength(2));
		}
		
		/// <summary>
		/// Returns the dimension of this array.
		/// </summary>
		/// <param name="array">The array.</param>
		/// <returns>The dimensions.</returns>
		public static Point4D GetDimensions<T>(this T[,,,] array)
		{
			return new Point4D(array.GetLength(0), array.GetLength(1), array.GetLength(2), array.GetLength(4));
		}
		
		/// <summary>
        /// Component-wise clips the given <see cref="Vec1D"/> to between min and max.
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise clipped vec.</returns>
        public static Vec1D Clip(Vec1D value, Vec1D min, Vec1D max)
        {
        	Vec1D vec = value;
        	if(value.X <= min.X) vec.X = min.X;
        	else if(value.X >= max.X) vec.X = max.X;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise clips the given <see cref="Vec2D"/> to between min and max.
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise clipped vec.</returns>
        public static Vec2D Clip(Vec2D value, Vec2D min, Vec2D max)
        {
        	Vec2D vec = value;
        	if(value.X <= min.X) vec.X = min.X;
        	else if(value.X >= max.X) vec.X = max.X;
        	
        	if(value.Y <= min.Y) vec.Y = min.Y;
        	else if(value.Y >= max.Y) vec.Y = max.Y;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise clips the given <see cref="Vec3D"/> to between min and max.
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise clipped vec.</returns>
        public static Vec3D Clip(Vec3D value, Vec3D min, Vec3D max)
        {
        	Vec3D vec = value;
        	if(value.X <= min.X) vec.X = min.X;
        	else if(value.X >= max.X) vec.X = max.X;
        	
        	if(value.Y <= min.Y) vec.Y = min.Y;
        	else if(value.Y >= max.Y) vec.Y = max.Y;
        	
        	if(value.Z <= min.Z) vec.Z = min.Z;
        	else if(value.Z >= max.Z) vec.Z = max.Z;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise clips the given <see cref="Vec4D"/> to between min and max.
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise clipped vec.</returns>
        public static Vec4D Clip(Vec4D value, Vec4D min, Vec4D max)
        {
        	Vec4D vec = value;
        	if(value.X <= min.X) vec.X = min.X;
        	else if(value.X >= max.X) vec.X = max.X;
        	
        	if(value.Y <= min.Y) vec.Y = min.Y;
        	else if(value.Y >= max.Y) vec.Y = max.Y;
        	
        	if(value.Z <= min.Z) vec.Z = min.Z;
        	else if(value.Z >= max.Z) vec.Z = max.Z;
        	
        	if(value.W <= min.W) vec.W = min.W;
        	else if(value.W >= max.W) vec.W = max.W;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise wraps the given <see cref="Vec1D"/> to between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise wrapped vec.</returns>
        public static Vec1D Wrap(Vec1D value, Vec1D min, Vec1D max)
        {
        	Vec1D vec = value;
        	vec.X -= min.X;
			vec.X %= max.X - min.X;
        	if(vec.X< 0) vec.X += max.X - min.X;
        	vec.X += min.X;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise wraps the given <see cref="Vec2D"/> to between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise wrapped vec.</returns>
        public static Vec2D Wrap(Vec2D value, Vec2D min, Vec2D max)
        {
        	Vec2D vec = value;
        	vec.X -= min.X;
			vec.X %= max.X - min.X;
        	if(vec.X< 0) vec.X += max.X - min.X;
        	vec.X += min.X;
        	
        	vec.Y -= min.Y;
			vec.Y %= max.Y - min.Y;
        	if(vec.Y< 0) vec.Y += max.Y - min.Y;
        	vec.Y += min.Y;
        	return vec;
        }
		
        /// <summary>
        /// Component-wise wraps the given <see cref="Vec3D"/> to between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise wrapped vec.</returns>
        public static Vec3D Wrap(Vec3D value, Vec3D min, Vec3D max)
        {
        	Vec3D vec = value;
        	vec.X -= min.X;
			vec.X %= max.X - min.X;
        	if(vec.X< 0) vec.X += max.X - min.X;
        	vec.X += min.X;
        	
        	vec.Y -= min.Y;
			vec.Y %= max.Y - min.Y;
        	if(vec.Y< 0) vec.Y += max.Y - min.Y;
        	vec.Y += min.Y;
        	
        	vec.Z -= min.Z;
			vec.Z %= max.Z - min.Z;
        	if(vec.Z< 0) vec.Z += max.Z - min.Z;
        	vec.Z += min.Z;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise wraps the given <see cref="Vec4D"/> to between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise wrapped vec.</returns>
        public static Vec4D Wrap(Vec4D value, Vec4D min, Vec4D max)
        {
        	Vec4D vec = value;
        	vec.X -= min.X;
			vec.X %= max.X - min.X;
        	if(vec.X< 0) vec.X += max.X - min.X;
        	vec.X += min.X;
        	
        	vec.Y -= min.Y;
			vec.Y %= max.Y - min.Y;
        	if(vec.Y< 0) vec.Y += max.Y - min.Y;
        	vec.Y += min.Y;
        	
        	vec.Z -= min.Z;
			vec.Z %= max.Z - min.Z;
        	if(vec.Z< 0) vec.Z += max.Z - min.Z;
        	vec.Z += min.Z;
        	
        	vec.W -= min.W;
			vec.W %= max.W - min.W;
        	if(vec.W< 0) vec.W += max.W - min.W;
        	vec.W += min.W;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise clips the given <see cref="Point1D"/> to between min and max.
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise clipped vec.</returns>
        public static Point1D Clip(Point1D value, Point1D min, Point1D max)
        {
        	Point1D vec = value;
        	if(value.X <= min.X) vec.X = min.X;
        	else if(value.X >= max.X) vec.X = max.X;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise clips the given <see cref="Point2D"/> to between min and max.
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise clipped vec.</returns>
        public static Point2D Clip(Point2D value, Point2D min, Point2D max)
        {
        	Point2D vec = value;
        	if(value.X <= min.X) vec.X = min.X;
        	else if(value.X >= max.X) vec.X = max.X;
        	
        	if(value.Y <= min.Y) vec.Y = min.Y;
        	else if(value.Y >= max.Y) vec.Y = max.Y;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise clips the given <see cref="Point3D"/> to between min and max.
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise clipped vec.</returns>
        public static Point3D Clip(Point3D value, Point3D min, Point3D max)
        {
        	Point3D vec = value;
        	if(value.X <= min.X) vec.X = min.X;
        	else if(value.X >= max.X) vec.X = max.X;
        	
        	if(value.Y <= min.Y) vec.Y = min.Y;
        	else if(value.Y >= max.Y) vec.Y = max.Y;
        	
        	if(value.Z <= min.Z) vec.Z = min.Z;
        	else if(value.Z >= max.Z) vec.Z = max.Z;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise clips the given <see cref="Point4D"/> to between min and max.
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise clipped vec.</returns>
        public static Point4D Clip(Point4D value, Point4D min, Point4D max)
        {
        	Point4D vec = value;
        	if(value.X <= min.X) vec.X = min.X;
        	else if(value.X >= max.X) vec.X = max.X;
        	
        	if(value.Y <= min.Y) vec.Y = min.Y;
        	else if(value.Y >= max.Y) vec.Y = max.Y;
        	
        	if(value.Z <= min.Z) vec.Z = min.Z;
        	else if(value.Z >= max.Z) vec.Z = max.Z;
        	
        	if(value.W <= min.W) vec.W = min.W;
        	else if(value.W >= max.W) vec.W = max.W;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise wraps the given <see cref="Point1D"/> to between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise wrapped vec.</returns>
        public static Point1D Wrap(Point1D value, Point1D min, Point1D max)
        {
        	Point1D vec = value;
        	vec.X -= min.X;
			vec.X %= max.X - min.X;
        	if(vec.X< 0) vec.X += max.X - min.X;
        	vec.X += min.X;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise wraps the given <see cref="Point2D"/> to between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise wrapped vec.</returns>
        public static Point2D Wrap(Point2D value, Point2D min, Point2D max)
        {
        	Point2D vec = value;
        	vec.X -= min.X;
			vec.X %= max.X - min.X;
        	if(vec.X< 0) vec.X += max.X - min.X;
        	vec.X += min.X;
        	
        	vec.Y -= min.Y;
			vec.Y %= max.Y - min.Y;
        	if(vec.Y< 0) vec.Y += max.Y - min.Y;
        	vec.Y += min.Y;
        	return vec;
        }
		
        /// <summary>
        /// Component-wise wraps the given <see cref="Point3D"/> to between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise wrapped vec.</returns>
        public static Point3D Wrap(Point3D value, Point3D min, Point3D max)
        {
        	Point3D vec = value;
        	vec.X -= min.X;
			vec.X %= max.X - min.X;
        	if(vec.X< 0) vec.X += max.X - min.X;
        	vec.X += min.X;
        	
        	vec.Y -= min.Y;
			vec.Y %= max.Y - min.Y;
        	if(vec.Y< 0) vec.Y += max.Y - min.Y;
        	vec.Y += min.Y;
        	
        	vec.Z -= min.Z;
			vec.Z %= max.Z - min.Z;
        	if(vec.Z< 0) vec.Z += max.Z - min.Z;
        	vec.Z += min.Z;
        	return vec;
        }
        
        /// <summary>
        /// Component-wise wraps the given <see cref="Point4D"/> to between min (inclusive) and max (exclusive).
        /// </summary>
        /// <param name="value">The resulting value.</param>
        /// <param name="min">The min vec.</param>
        /// <param name="max">The max vec.</param>
        /// <returns>The component-wise wrapped vec.</returns>
        public static Point4D Wrap(Point4D value, Point4D min, Point4D max)
        {
        	Point4D vec = value;
        	vec.X -= min.X;
			vec.X %= max.X - min.X;
        	if(vec.X< 0) vec.X += max.X - min.X;
        	vec.X += min.X;
        	
        	vec.Y -= min.Y;
			vec.Y %= max.Y - min.Y;
        	if(vec.Y< 0) vec.Y += max.Y - min.Y;
        	vec.Y += min.Y;
        	
        	vec.Z -= min.Z;
			vec.Z %= max.Z - min.Z;
        	if(vec.Z< 0) vec.Z += max.Z - min.Z;
        	vec.Z += min.Z;
        	
        	vec.W -= min.W;
			vec.W %= max.W - min.W;
        	if(vec.W< 0) vec.W += max.W - min.W;
        	vec.W += min.W;
        	return vec;
        }
        
        /// <summary>
        /// Returns the component-wise max of the given vectors.
        /// </summary>
        /// <param name="vecs">The vectors.</param>
        /// <returns>The component-wise max vector.</returns>
        public static Vec1D Max(params Vec1D[] vecs)
        {
        	Vec1D max = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X > max.X)
        		{
        			max.X = vecs[i].X;
        		}
        	}
            return max;
        }
        
        /// <summary>
        /// Returns the component-wise max of the given vectors.
        /// </summary>
        /// <param name="vecs">The vectors.</param>
        /// <returns>The component-wise max vector.</returns>
        public static Vec2D Max(params Vec2D[] vecs)
        {
        	Vec2D max = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X > max.X)
        		{
        			max.X = vecs[i].X;
        		}
        		if(vecs[i].Y > max.Y)
        		{
        			max.Y = vecs[i].Y;
        		}
        	}
            return max;
        }
        
        /// <summary>
        /// Returns the component-wise max of the given vectors.
        /// </summary>
        /// <param name="vecs">The vectors.</param>
        /// <returns>The component-wise max vector.</returns>
        public static Vec3D Max(params Vec3D[] vecs)
        {
        	Vec3D max = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X > max.X)
        		{
        			max.X = vecs[i].X;
        		}
        		if(vecs[i].Y > max.Y)
        		{
        			max.Y = vecs[i].Y;
        		}
        		if(vecs[i].Z > max.Z)
        		{
        			max.Z = vecs[i].Z;
        		}
        	}
            return max;
        }
        
        /// <summary>
        /// Returns the component-wise max of the given vectors.
        /// </summary>
        /// <param name="vecs">The vectors.</param>
        /// <returns>The component-wise max vector.</returns>
        public static Vec4D Max(params Vec4D[] vecs)
        {
        	Vec4D max = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X > max.X)
        		{
        			max.X = vecs[i].X;
        		}
        		if(vecs[i].Y > max.Y)
        		{
        			max.Y = vecs[i].Y;
        		}
        		if(vecs[i].Z > max.Z)
        		{
        			max.Z = vecs[i].Z;
        		}
        		if(vecs[i].W > max.W)
        		{
        			max.W = vecs[i].W;
        		}
        	}
            return max;
        }
        
        /// <summary>
        /// Returns the component-wise min of the given vectors.
        /// </summary>
        /// <param name="vecs">The vectors.</param>
        /// <returns>The component-wise min vector.</returns>
        public static Vec1D Min(params Vec1D[] vecs)
        {
        	Vec1D min = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X < min.X)
        		{
        			min.X = vecs[i].X;
        		}
        	}
            return min;
        }
        
        /// <summary>
        /// Returns the component-wise min of the given vectors.
        /// </summary>
        /// <param name="vecs">The vectors.</param>
        /// <returns>The component-wise min vector.</returns>
        public static Vec2D Min(params Vec2D[] vecs)
        {
        	Vec2D min = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X < min.X)
        		{
        			min.X = vecs[i].X;
        		}
        		if(vecs[i].Y < min.Y)
        		{
        			min.Y = vecs[i].Y;
        		}
        	}
            return min;
        }
        
        /// <summary>
        /// Returns the component-wise min of the given vectors.
        /// </summary>
        /// <param name="vecs">The vectors.</param>
        /// <returns>The component-wise min vector.</returns>
        public static Vec3D Min(params Vec3D[] vecs)
        {
        	Vec3D min = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X < min.X)
        		{
        			min.X = vecs[i].X;
        		}
        		if(vecs[i].Y < min.Y)
        		{
        			min.Y = vecs[i].Y;
        		}
        		if(vecs[i].Z < min.Z)
        		{
        			min.Z = vecs[i].Z;
        		}
        	}
            return min;
        }
        
        /// <summary>
        /// Returns the component-wise min of the given vectors.
        /// </summary>
        /// <param name="vecs">The vectors.</param>
        /// <returns>The component-wise min vector.</returns>
        public static Vec4D Min(params Vec4D[] vecs)
        {
        	Vec4D min = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X < min.X)
        		{
        			min.X = vecs[i].X;
        		}
        		if(vecs[i].Y < min.Y)
        		{
        			min.Y = vecs[i].Y;
        		}
        		if(vecs[i].Z < min.Z)
        		{
        			min.Z = vecs[i].Z;
        		}
        		if(vecs[i].W < min.W)
        		{
        			min.W = vecs[i].W;
        		}
        	}
            return min;
        }
        
        /// <summary>
        /// Returns the component-wise max of the given points.
        /// </summary>
        /// <param name="vecs">The points.</param>
        /// <returns>The component-wise max vector.</returns>
        public static Point1D Max(params Point1D[] vecs)
        {
        	Point1D max = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X > max.X)
        		{
        			max.X = vecs[i].X;
        		}
        	}
            return max;
        }
        
        /// <summary>
        /// Returns the component-wise max of the given points.
        /// </summary>
        /// <param name="vecs">The points.</param>
        /// <returns>The component-wise max vector.</returns>
        public static Point2D Max(params Point2D[] vecs)
        {
        	Point2D max = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X > max.X)
        		{
        			max.X = vecs[i].X;
        		}
        		if(vecs[i].Y > max.Y)
        		{
        			max.Y = vecs[i].Y;
        		}
        	}
            return max;
        }
        
        /// <summary>
        /// Returns the component-wise max of the given points.
        /// </summary>
        /// <param name="vecs">The points.</param>
        /// <returns>The component-wise max vector.</returns>
        public static Point3D Max(params Point3D[] vecs)
        {
        	Point3D max = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X > max.X)
        		{
        			max.X = vecs[i].X;
        		}
        		if(vecs[i].Y > max.Y)
        		{
        			max.Y = vecs[i].Y;
        		}
        		if(vecs[i].Z > max.Z)
        		{
        			max.Z = vecs[i].Z;
        		}
        	}
            return max;
        }
        
        /// <summary>
        /// Returns the component-wise max of the given points.
        /// </summary>
        /// <param name="vecs">The points.</param>
        /// <returns>The component-wise max vector.</returns>
        public static Point4D Max(params Point4D[] vecs)
        {
        	Point4D max = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X > max.X)
        		{
        			max.X = vecs[i].X;
        		}
        		if(vecs[i].Y > max.Y)
        		{
        			max.Y = vecs[i].Y;
        		}
        		if(vecs[i].Z > max.Z)
        		{
        			max.Z = vecs[i].Z;
        		}
        		if(vecs[i].W > max.W)
        		{
        			max.W = vecs[i].W;
        		}
        	}
            return max;
        }
        
        /// <summary>
        /// Returns the component-wise min of the given points.
        /// </summary>
        /// <param name="vecs">The points.</param>
        /// <returns>The component-wise min vector.</returns>
        public static Point1D Min(params Point1D[] vecs)
        {
        	Point1D min = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X < min.X)
        		{
        			min.X = vecs[i].X;
        		}
        	}
            return min;
        }
        
        /// <summary>
        /// Returns the component-wise min of the given points.
        /// </summary>
        /// <param name="vecs">The points.</param>
        /// <returns>The component-wise min vector.</returns>
        public static Point2D Min(params Point2D[] vecs)
        {
        	Point2D min = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X < min.X)
        		{
        			min.X = vecs[i].X;
        		}
        		if(vecs[i].Y < min.Y)
        		{
        			min.Y = vecs[i].Y;
        		}
        	}
            return min;
        }
        
        /// <summary>
        /// Returns the component-wise min of the given points.
        /// </summary>
        /// <param name="vecs">The points.</param>
        /// <returns>The component-wise min vector.</returns>
        public static Point3D Min(params Point3D[] vecs)
        {
        	Point3D min = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X < min.X)
        		{
        			min.X = vecs[i].X;
        		}
        		if(vecs[i].Y < min.Y)
        		{
        			min.Y = vecs[i].Y;
        		}
        		if(vecs[i].Z < min.Z)
        		{
        			min.Z = vecs[i].Z;
        		}
        	}
            return min;
        }
        
        /// <summary>
        /// Returns the component-wise min of the given points.
        /// </summary>
        /// <param name="vecs">The points.</param>
        /// <returns>The component-wise min vector.</returns>
        public static Point4D Min(params Point4D[] vecs)
        {
        	Point4D min = vecs[0];
        	for(int i = 1; i < vecs.Length; i++)
        	{
        		if(vecs[i].X < min.X)
        		{
        			min.X = vecs[i].X;
        		}
        		if(vecs[i].Y < min.Y)
        		{
        			min.Y = vecs[i].Y;
        		}
        		if(vecs[i].Z < min.Z)
        		{
        			min.Z = vecs[i].Z;
        		}
        		if(vecs[i].W < min.W)
        		{
        			min.W = vecs[i].W;
        		}
        	}
            return min;
        }
        
        /// <summary>
        /// Interpolates between the given vectors using the given interpolation function.
        /// </summary>
        /// <param name="bottom">The bottom value.</param>
        /// <param name="top">The top value.</param>
        /// <param name="mu">The mu value.</param>
        /// <param name="func">The interpolation function to use.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec1D Interpolate(Vec1D bottom, Vec1D top, double mu, InterpFunction func)
        {
        	return new Vec1D(func(bottom.X, top.X, mu));
        }
        
        /// <summary>
        /// Interpolates between the given vectors using the given interpolation function.
        /// </summary>
        /// <param name="bottom">The bottom value.</param>
        /// <param name="top">The top value.</param>
        /// <param name="mu">The mu value.</param>
        /// <param name="func">The interpolation function to use.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec2D Interpolate(Vec2D bottom, Vec2D top, double mu, InterpFunction func)
        {
        	return new Vec2D(func(bottom.X, top.X, mu), 
        	                 func(bottom.Y, top.Y, mu));
        }
        
        /// <summary>
        /// Interpolates between the given vectors using the given interpolation function.
        /// </summary>
        /// <param name="bottom">The bottom value.</param>
        /// <param name="top">The top value.</param>
        /// <param name="mu">The mu value.</param>
        /// <param name="func">The interpolation function to use.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec3D Interpolate(Vec3D bottom, Vec3D top, double mu, InterpFunction func)
        {
        	return new Vec3D(func(bottom.X, top.X, mu), 
        	                 func(bottom.Y, top.Y, mu),
        	                 func(bottom.Z, top.Z, mu));
        }
        
        /// <summary>
        /// Interpolates between the given vectors using the given interpolation function.
        /// </summary>
        /// <param name="bottom">The bottom value.</param>
        /// <param name="top">The top value.</param>
        /// <param name="mu">The mu value.</param>
        /// <param name="func">The interpolation function to use.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec4D Interpolate(Vec4D bottom, Vec4D top, double mu, InterpFunction func)
        {
        	return new Vec4D(func(bottom.X, top.X, mu), 
        	                 func(bottom.Y, top.Y, mu),
        	                 func(bottom.Z, top.Z, mu),
        	                 func(bottom.W, top.W, mu));
        }
        
        /// <summary>
        /// Interpolates between the given vectors using the given extended interpolation function.
        /// </summary>
        /// <param name="past">The past value.</param>
        /// <param name="bottom">The bottom value.</param>
        /// <param name="top">The top value.</param>
        /// <param name="future">The future value.</param>
        /// <param name="mu">The mu value.</param>
        /// <param name="func">The extended interpolation function to use.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec1D Interpolate(Vec1D past, Vec1D bottom, Vec1D top, Vec1D future, double mu, ExtendedInterpFunction func)
        {
        	return new Vec1D(func(past.X, bottom.X, top.X, future.X, mu));
        }
        
        /// <summary>
        /// Interpolates between the given vectors using the given extended interpolation function.
        /// </summary>
        /// <param name="past">The past value.</param>
        /// <param name="bottom">The bottom value.</param>
        /// <param name="top">The top value.</param>
        /// <param name="future">The future value.</param>
        /// <param name="mu">The mu value.</param>
        /// <param name="func">The extended interpolation function to use.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec2D Interpolate(Vec2D past, Vec2D bottom, Vec2D top, Vec2D future, double mu, ExtendedInterpFunction func)
        {
        	return new Vec2D(func(past.X, bottom.X, top.X, future.X, mu),
        	                 func(past.Y, bottom.Y, top.Y, future.Y, mu));
        }
        
        /// <summary>
        /// Interpolates between the given vectors using the given extended interpolation function.
        /// </summary>
        /// <param name="past">The past value.</param>
        /// <param name="bottom">The bottom value.</param>
        /// <param name="top">The top value.</param>
        /// <param name="future">The future value.</param>
        /// <param name="mu">The mu value.</param>
        /// <param name="func">The extended interpolation function to use.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec3D Interpolate(Vec3D past, Vec3D bottom, Vec3D top, Vec3D future, double mu, ExtendedInterpFunction func)
        {
        	return new Vec3D(func(past.X, bottom.X, top.X, future.X, mu),
        	                 func(past.Y, bottom.Y, top.Y, future.Y, mu),
        	                 func(past.Z, bottom.Z, top.Z, future.Z, mu));
        }
        
        /// <summary>
        /// Interpolates between the given vectors using the given extended interpolation function.
        /// </summary>
        /// <param name="past">The past value.</param>
        /// <param name="bottom">The bottom value.</param>
        /// <param name="top">The top value.</param>
        /// <param name="future">The future value.</param>
        /// <param name="mu">The mu value.</param>
        /// <param name="func">The extended interpolation function to use.</param>
        /// <returns>The resulting vector.</returns>
        public static Vec4D Interpolate(Vec4D past, Vec4D bottom, Vec4D top, Vec4D future, double mu, ExtendedInterpFunction func)
        {
        	return new Vec4D(func(past.X, bottom.X, top.X, future.X, mu),
        	                 func(past.Y, bottom.Y, top.Y, future.Y, mu),
        	                 func(past.Z, bottom.Z, top.Z, future.Z, mu),
        	                 func(past.W, bottom.W, top.W, future.W, mu));
        }
	}
}
