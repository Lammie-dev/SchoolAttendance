using System;

public class ActionResponse
{
	public bool Success { get { return ErrorMessage == null; } }
	public string ErrorMessage { get; set; }
	public object Result { get; set; }
	public int StatusCode { get; set; }
}
