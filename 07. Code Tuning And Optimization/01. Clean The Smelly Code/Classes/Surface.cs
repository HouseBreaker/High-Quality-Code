namespace SolarSystem.Classes
{
	using System;
	using System.Windows;
	using System.Windows.Media.Media3D;

	public abstract class Surface : ModelVisual3D
    {
        public Surface()
        {
            this.Content = this._content;
            this._content.Geometry = this.CreateMesh();
        }

        public static PropertyHolder<Material, Surface> MaterialProperty =
            new PropertyHolder<Material,Surface>("Material", null, OnMaterialChanged);

        public static PropertyHolder<Material, Surface> BackMaterialProperty =
            new PropertyHolder<Material, Surface>("BackMaterial", null, OnBackMaterialChanged);

        public static PropertyHolder<bool, Surface> VisibleProperty =
            new PropertyHolder<bool, Surface>("Visible", true, OnVisibleChanged);

        public Material Material
        {
            get { return MaterialProperty.Get(this); }
            set { MaterialProperty.Set(this, value); }
        }

        public Material BackMaterial
        {
            get { return BackMaterialProperty.Get(this); }
            set { BackMaterialProperty.Set(this, value); }
        }

        public bool Visible
        {
            get { return VisibleProperty.Get(this); }
            set { VisibleProperty.Set(this, value); }
        }

        private static void OnMaterialChanged(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnMaterialChanged();
        }

        private static void OnBackMaterialChanged(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnBackMaterialChanged();
        }

        private static void OnVisibleChanged(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnVisibleChanged();
        }

        protected static void OnGeometryChanged(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnGeometryChanged();
        }

        private void OnMaterialChanged()
        {
            this.SetContentMaterial();
        }

        private void OnBackMaterialChanged()
        {
            this.SetContentBackMaterial();
        }

        private void OnVisibleChanged()
        {
            this.SetContentMaterial();
            this.SetContentBackMaterial();
        }

        private void SetContentMaterial()
        {
            this._content.Material = this.Visible ? this.Material : null;
        }

        private void SetContentBackMaterial()
        {
            this._content.BackMaterial = this.Visible ? this.BackMaterial : null;
        }

        private void OnGeometryChanged()
        {
            this._content.Geometry = this.CreateMesh();
        }

        protected abstract Geometry3D CreateMesh();

        private readonly GeometryModel3D _content = new GeometryModel3D();
    }
}
