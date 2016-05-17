using System.Collections.Generic;

namespace MumukiLoader {
	public static class Locales {
		private static IDictionary<string, string> locales = new Dictionary<string, string> {
			{ "PreparingThings", "Estamos preparando algunas cosas, esperá un momento por favor..." },
			{ "Loading", "Cargando..." },
			{ "SUCCESS", "¡Perfecto!" },
			{ "RESTARTNEEDED", "El instalador necesita reiniciar Windows." },
			{ "ERROR", "Algo salió mal." }
		};

		public static string ValueFor(string key)
		{
			return locales[key];
		}
	}
}
