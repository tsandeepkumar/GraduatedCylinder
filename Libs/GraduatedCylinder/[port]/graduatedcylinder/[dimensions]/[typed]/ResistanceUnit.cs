namespace GraduatedCylinder
{
	/// <summary>
	///     Units of Electric Resistance that are currently supported, Ohms is the Base Unit.
	/// </summary>
	public enum ResistanceUnit
	{
		/// <summary>
		///     Ohms, This is the Base Unit
		/// </summary>
		BaseUnit = Ohms,

		/// <summary>
		///     Ohms, this is the Base Unit
		/// </summary>
		[UnitAbbreviation("Ω")]
		[Scale(1.0)]
		Ohms = 0,

		/// <summary>
		///     KiloOhms
		/// </summary>
		[UnitAbbreviation("kΩ")]
		[Scale(1e3)]
		KiloOhms = 1,

		/// <summary>
		///     MilliOhms
		/// </summary>
		[UnitAbbreviation("mΩ")]
		[Scale(1e-3)]
		MilliOhms = 2,
	}
}