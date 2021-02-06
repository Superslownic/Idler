using UnityEngine;
using UnityEngine.UI;

namespace Idler.Presenters
{
    public class TextPresenter : MonoBehaviour, IPresenter<string>
    {
        [SerializeField] private Text _textField;
        [SerializeField] private string _format;

        public void Present(string data)
        {
            _textField.text = string.Format(_format, data.ToString());
        }
    }
}
