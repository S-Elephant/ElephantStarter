namespace ElephantStarter
{
	/// <summary>
	/// Message box extended.
	/// </summary>
	public static class MessageBoxExt
	{
		/// <summary>
		/// Show an info <see cref="MessageBox"/>.
		/// </summary>
		public static DialogResult ShowInfo(string infoMessage, string caption = "Info")
		{
			return MessageBox.Show(infoMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Show an error <see cref="MessageBox"/>.
		/// </summary>
		public static DialogResult ShowError(string errorMessage, string caption = "Error")
		{
			return MessageBox.Show(errorMessage, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
