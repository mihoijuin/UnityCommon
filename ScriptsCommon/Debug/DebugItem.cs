using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugItem : MonoBehaviour
{
    [SerializeField]
    private Dropdown dropdown = null;
    [SerializeField]
    private Toggle chekbox = null;
    [SerializeField]
    private InputField textField = null;

    [SerializeField]
    private Text title = null;
    [SerializeField]
    private Text currentValue = null;

    public enum Input { Dropdown, Checkbox, TextField }
    private Input input;

    private Type group;

    public void Init(Type type) {
        group = type;
        title.text = type.GetField("title").GetValue(null).ToString();

        input = (Input)type.GetField("input").GetValue(null);
        switch(input) {
            case Input.Dropdown:
            string[] optionList = (string[])type.GetField("optionList").GetValue(null);
            dropdown.AddOptions(new List<string> (optionList));
            dropdown.gameObject.SetActive(true);
            break;
            case Input.Checkbox:
            chekbox.gameObject.SetActive(true);
            break;
            case Input.TextField:
            textField.gameObject.SetActive(true);
            break;
        }
    }

    private void OnEnable() {
        Show();
    }

    public void Show() {
        object groupReturn = GetGroupReturn();
        Type returnType = groupReturn.GetType();
        string valueString = groupReturn.ToString();
        currentValue.text = valueString;

        switch(input) {
            case Input.Dropdown:
            int index = 0;
            if(returnType.IsEnum) {
                index = (int)Enum.Parse(returnType, valueString);
            }
            dropdown.value = index;
            break;
        }
    }

    public void Fix() {
        MethodInfo method = group.GetMethod("Set");
        switch(input) {
            case Input.Dropdown:
            string newValue = dropdown.captionText.text;
            int index = dropdown.value;
            Type returnType = GetGroupReturn().GetType();
            if(returnType.IsEnum)
            {
                method.Invoke(null, new object[] {Enum.GetValues(returnType).GetValue(index)});
            }
            break;
        }
    }

    private object GetGroupReturn() {
        return group.GetMethod("Get").Invoke(null, null);
    }

}
