using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;

public static class EtatClavier
{
	public static FrameworkElement mEcouteur {get; private set;}
	private static Dictionary<Key, bool> mTouchesEnfoncees;
	public static void Ecouter(FrameworkElement element)
	{
		mTouchesEnfoncees = new Dictionary<Key, bool>();
		mEcouteur = element;
		mEcouteur.KeyDown += new KeyEventHandler(mEcouteur_KeyDown);
		mEcouteur.KeyUp += new KeyEventHandler(mEcouteur_KeyUp);
		mEcouteur.LostFocus += new RoutedEventHandler(mEcouteur_LostFocus);
	}
	
	// touche enfoncée
	private static void mEcouteur_KeyDown(object sender, KeyEventArgs e)
	{
		if (!mTouchesEnfoncees.ContainsKey(e.Key))
		{
			mTouchesEnfoncees.Add(e.Key, true);
		}
	}
	
	// touche relachée
	private static void mEcouteur_KeyUp(object sender, KeyEventArgs e)
	{
		if (mTouchesEnfoncees.ContainsKey(e.Key))
		{
			mTouchesEnfoncees.Remove(e.Key);
		}
	}
	
	// perte du focus
	private static void mEcouteur_LostFocus(object sender, RoutedEventArgs e)
	{
		mTouchesEnfoncees.Clear();
	}
	
	// test d'une touche
	public static bool ToucheEnfoncee(Key k)
	{
		return mTouchesEnfoncees.ContainsKey(k);
	}
}

