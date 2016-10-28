using UnityEngine;
using System.Collections;
using System;

public interface IRestartableDurationCommand
{
  void ExecuteDuration(float duration);
}
