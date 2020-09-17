using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumProject.Settings;

namespace SeleniumProject.ComponentHelper
{
    public class ActionsHelper : BaseComponentHelper

    {

        private static Actions Action => new Actions(ObjectRepository.Driver);

        public static void MoveToElementAndClick(IWebElement element)
        {
            Logger.Info($"Moving to element: {element.ToString()} and clicking");
            Action.MoveToElement(element).Click(element).Build().Perform();
        }

        public static void MoveToElementAndDoubleClick(IWebElement element)
        {
            Logger.Info($"Moving to element: {element}  and double clicking");
            Action.MoveToElement(element).DoubleClick(element).Build().Perform();
        }

        public static void MoveToElementAndRightClick(IWebElement element)
        {
            Logger.Info($"Moving to element: {element}  and right clicking");
            Action.MoveToElement(element).ContextClick(element).Build().Perform();
        }

        public static void ClickOnElement(IWebElement element)
        {
            Logger.Info($"Right click on element: {element} ");
            Action.Click(element).Build().Perform();
        }

        public static void DoubleClickOnElement(IWebElement element)
        {
            Logger.Info($"Right click on element: {element} ");
            Action.DoubleClick(element).Build().Perform();
        }

        public static void RightClickOnElement(IWebElement element)
        {
            Logger.Info($"Right click on element: {element} ");
            Action.ContextClick(element).Build().Perform();
        }

        public static void DragAndDrop(IWebElement sourceElement, IWebElement targetElement)
        {
            Logger.Info($"Dragging and dropping from: {sourceElement} to {targetElement}");
            Action.DragAndDrop(sourceElement, targetElement).Build().Perform();
        }

        public static void ClickAndHoldAndMove(IWebElement sourceElement, IWebElement targetElement)
        {
            Logger.Info($"Click and hold element: {sourceElement} and move to {targetElement}");
            Action.ClickAndHold(sourceElement).MoveToElement(targetElement).Release().Build().Perform();
        }

        public static void ClickAndHoldAndMoveWithOffSet(IWebElement sourceElement, IWebElement targetElement, int xOffset, int yOffset)
        {
            Logger.Info($"Click and hold element: {sourceElement} and move to {targetElement} with X offset: {xOffset} and Y offset: {yOffset}");
            Action.ClickAndHold(sourceElement).MoveToElement(targetElement, xOffset, yOffset).Release().Build().Perform();
        }

        /// <summary>
        /// Pass in a Keys.key and action will press down and up
        /// </summary>
        /// <param name="key"></param>
        public static void PressKey(string key)
        {
            Logger.Info($"Press key: {key}");
            Action.KeyDown(key).KeyUp(key).Build().Perform();
        }

        public static void PressKeyCombination(string key1, string key2)
        {
            Logger.Info($"Press key combination: {key1} + {key2}");
            Action.KeyDown(key1).KeyDown(key2).KeyUp(key1).KeyUp(key2).Build().Perform();
        }


    }
}
