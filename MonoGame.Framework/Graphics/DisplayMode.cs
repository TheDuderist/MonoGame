#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2014 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */

/* Derived from code by the Mono.Xna Team (Copyright 2006).
 * Released under the MIT License. See monoxna.LICENSE for details.
 */
#endregion License

#region Using Statements
using System.Globalization;
using System.Runtime.Serialization;
#endregion

namespace Microsoft.Xna.Framework.Graphics
{
	[DataContract]
	public class DisplayMode
	{
		#region Public Properties

		public float AspectRatio
		{
			get
			{
				return (float) Width / (float) Height;
			}
		}

		public SurfaceFormat Format
		{
			get;
			private set;
		}

		public int Height
		{
			get;
			private set;
		}

		public int Width
		{
			get;
			private set;
		}

		public Rectangle TitleSafeArea
		{
			get
			{
				return new Rectangle(0, 0, Width, Height);
			}
		}

		#endregion

		#region Internal Constructor

		internal DisplayMode(int width, int height, SurfaceFormat format)
		{
			Width = width;
			Height = height;
			Format = format;
		}

		#endregion

		#region Public Static Operators and Override Methods

		public static bool operator !=(DisplayMode left, DisplayMode right)
		{
			return !(left == right);
		}

		public static bool operator ==(DisplayMode left, DisplayMode right)
		{
			if (ReferenceEquals(left, right)) // Same object or both are null
			{
				return true;
			}
			if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
			{
				return false;
			}
			return (	(left.Format == right.Format) &&
					(left.Height == right.Height) &&
					(left.Width == right.Width)	);
		}

		public override bool Equals(object obj)
		{
			return (obj as DisplayMode) == this;
		}

		public override int GetHashCode()
		{
			return (Width.GetHashCode() ^ Height.GetHashCode() ^ Format.GetHashCode());
		}

		public override string ToString()
		{
			return string.Format(
				CultureInfo.CurrentCulture,
				"{{Width:{0} Height:{1} Format:{2}}}",
				new object[]
				{
					Width,
					Height,
					Format
				}
			);
		}

		#endregion
	}
}
