using System;

namespace Masterplan.Extensibility
{
	/// <summary>
	/// Interface implemented by add-in commands.
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// Gets the name of the command.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the description of the command.
		/// </summary>
		string Description { get; }

		/// <summary>
		/// Gets a value indicating whether the command is currently available to be executed.
		/// </summary>
		bool Available { get; }

		/// <summary>
		/// Gets a value indicating whether the command is currently running.
		/// </summary>
		bool Active { get; }

		/// <summary>
		/// Performs the command.
		/// </summary>
		void Execute();
	}
}
