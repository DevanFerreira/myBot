﻿using MoonSharp.Interpreter;
using myBot.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace myBot.Controls
{
    [MoonSharpUserData]
    public class cElementContainer<T> : cElement<T>
        where T : Element
    {
        private ElementContainer<T> obj;

        public cElementContainer(ElementContainer<T> baseObject)
            : base(baseObject)
        {
            obj = baseObject;
        }

        #region Properties

        public cAreaCollection Areas
        {
            get { return new cAreaCollection(obj.Areas); }
        }

        public cButtonCollection Buttons
        {
            get { return new cButtonCollection(obj.Buttons); }
        }

        public cCheckBoxCollection CheckBoxes
        {
            get { return new cCheckBoxCollection(obj.CheckBoxes); }
        }

        public cDivCollection Divs
        {
            get { return new cDivCollection(obj.Divs); }
        }

        public cElementCollection Elements
        {
            get { return new cElementCollection(obj.Elements); }
        }

        public cFileUploadCollection FileUploads
        {
            get { return new cFileUploadCollection(obj.FileUploads); }
        }

        public cFormCollection Forms
        {
            get { return new cFormCollection(obj.Forms); }
        }

        public cImageCollection Images
        {
            get { return new cImageCollection(obj.Images); }
        }

        public cLabelCollection Labels
        {
            get { return new cLabelCollection(obj.Labels); }
        }

        public cLinkCollection Links
        {
            get { return new cLinkCollection(obj.Links); }
        }

        public cListItemCollection ListItems
        {
            get { return new cListItemCollection(obj.ListItems); }
        }

        public cListCollection Lists
        {
            get { return new cListCollection(obj.Lists); }
        }

        public cParaCollection Paragraphs
        {
            get { return new cParaCollection(obj.Paras); }
        }

        public cRadioButtonCollection RadioButtons
        {
            get { return new cRadioButtonCollection(obj.RadioButtons); }
        }

        public cSelectListCollection SelectLists
        {
            get { return new cSelectListCollection(obj.SelectLists); }
        }

        public cSpanCollection Spans
        {
            get { return new cSpanCollection(obj.Spans); }
        }

        public cTableBodyCollection TableBodies
        {
            get { return new cTableBodyCollection(obj.TableBodies); }
        }

        public cTableCellCollection TableCells
        {
            get { return new cTableCellCollection(obj.TableCells); }
        }

        public cTableRowCollection TableRows
        {
            get { return new cTableRowCollection(obj.TableRows); }
        }

        public cTableCollection Tables
        {
            get { return new cTableCollection(obj.Tables); }
        }

        public cTextFieldCollection TextFields
        {
            get { return new cTextFieldCollection(obj.TextFields); }
        }

        public cElementCollection Children
        {
            get { return new cElementCollection(obj.Children()); }
        }

        #endregion

        #region Functions

        #region Area

        public virtual cArea FindArea(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cArea(obj.Area(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cArea(obj.Area(findBy.String));
        }

        public virtual cAreaCollection FindAreas(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cAreaCollection(obj.Areas.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Button

        public virtual cButton FindButton(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cButton(obj.Button(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cButton(obj.Button(findBy.String));
        }

        public virtual cButtonCollection FindButtons(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cButtonCollection(obj.Buttons.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region CheckBox

        public virtual cCheckBox FindCheckBox(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cCheckBox(obj.CheckBox(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cCheckBox(obj.CheckBox(findBy.String));
        }

        public virtual cCheckBoxCollection FindCheckBoxes(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cCheckBoxCollection(obj.CheckBoxes.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Child

        public virtual DynValue FindChild(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return Helpers.ParseElement(obj.Child(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return Helpers.ParseElement(obj.Child(findBy.String));
        }

        public virtual cElementCollection FindChildren(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cElementCollection(obj.Children().Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        public virtual DynValue FindChildWithTag(string tag, DynValue findBy, DynValue s1, DynValue s2)
        {
            return Helpers.ParseElement(obj.ChildWithTag(tag, Helpers.ParseConstraint(findBy, s1, s2)));
        }

        public virtual cElementCollection FindChildrenWithTag(string tag)
        {
            return new cElementCollection(obj.ChildrenWithTag(tag));
        }

        #endregion

        #region Div

        public virtual cDiv FindDiv(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cDiv(obj.Div(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cDiv(obj.Div(findBy.String));
        }

        public virtual cDivCollection FindDivs(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cDivCollection(obj.Divs.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Element

        public virtual DynValue FindElement(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return Helpers.ParseElement(obj.Element(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return Helpers.ParseElement(obj.Element(findBy.String));
        }

        public virtual cElementCollection FindElements(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cElementCollection(obj.Elements.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        public virtual DynValue FindElementWithTag(string tag, DynValue findBy, DynValue s1, DynValue s2)
        {
            return Helpers.ParseElement(obj.ElementWithTag(tag, Helpers.ParseConstraint(findBy, s1, s2)));
        }

        public virtual cElementCollection FindElementsWithTag(string tag)
        {
            return new cElementCollection(obj.ElementsWithTag(tag));
        }

        #endregion

        #region FileUpload

        public virtual cFileUpload FindFileUpload(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cFileUpload(obj.FileUpload(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cFileUpload(obj.FileUpload(findBy.String));
        }

        public virtual cFileUploadCollection FindFileUploads(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cFileUploadCollection(obj.FileUploads.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Form

        public virtual cForm cFormCollection(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cForm(obj.Form(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cForm(obj.Form(findBy.String));
        }

        public virtual cFormCollection cFormCollections(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cFormCollection(obj.Forms.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Image

        public virtual cImage FindImage(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cImage(obj.Image(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cImage(obj.Image(findBy.String));
        }

        public virtual cImageCollection FindImages(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cImageCollection(obj.Images.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Label

        public virtual cLabel FindLabel(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cLabel(obj.Label(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cLabel(obj.Label(findBy.String));
        }

        public virtual cLabelCollection FindLabels(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cLabelCollection(obj.Labels.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Link

        public virtual cLink FindLink(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cLink(obj.Link(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cLink(obj.Link(findBy.String));
        }

        public virtual cLinkCollection FindLinks(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cLinkCollection(obj.Links.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region List

        public virtual cList FindList(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cList(obj.List(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cList(obj.List(findBy.String));
        }

        public virtual cListCollection FindLists(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cListCollection(obj.Lists.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region ListItem

        public virtual cListItem FindListItem(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cListItem(obj.ListItem(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cListItem(obj.ListItem(findBy.String));
        }

        public virtual cListItemCollection FindListItems(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cListItemCollection(obj.ListItems.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Para

        public virtual cPara FindParagraph(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cPara(obj.Para(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cPara(obj.Para(findBy.String));
        }

        public virtual cParaCollection FindParagraphs(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cParaCollection(obj.Paras.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region RadioButton

        public virtual cRadioButton FindRadioButton(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cRadioButton(obj.RadioButton(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cRadioButton(obj.RadioButton(findBy.String));
        }

        public virtual cRadioButtonCollection FindRadioButtons(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cRadioButtonCollection(obj.RadioButtons.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region SelectList

        public virtual cSelectList FindSelectList(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cSelectList(obj.SelectList(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cSelectList(obj.SelectList(findBy.String));
        }

        public virtual cSelectListCollection FindSelectLists(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cSelectListCollection(obj.SelectLists.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Span

        public virtual cSpan FindSpan(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cSpan(obj.Span(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cSpan(obj.Span(findBy.String));
        }

        public virtual cSpanCollection FindSpans(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cSpanCollection(obj.Spans.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region Table

        public virtual cTable FindTable(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cTable(obj.Table(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cTable(obj.Table(findBy.String));
        }

        public virtual cTableCollection FindTables(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cTableCollection(obj.Tables.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region TableBody

        public virtual cTableBody FindTableBody(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cTableBody(obj.TableBody(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cTableBody(obj.TableBody(findBy.String));
        }

        public virtual cTableBodyCollection FindTableBodies(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cTableBodyCollection(obj.TableBodies.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region TableCell

        public virtual cTableCell FindTableCell(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
            {
                if ((findBy.Type == DataType.String) && (s1.Type == DataType.Number))
                    return new cTableCell(obj.TableCell(Find.ById(findBy.String) && Find.ByIndex(Convert.ToInt32(s1.Number))));
                else
                    return new cTableCell(obj.TableCell(Helpers.ParseConstraint(findBy, s1, s2)));
            }
            else
                return new cTableCell(obj.TableCell(findBy.String));
        }

        public virtual cTableCellCollection FindTableCells(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cTableCellCollection(obj.TableCells.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region TableRow

        public virtual cTableRow FindTableRow(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cTableRow(obj.TableRow(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cTableRow(obj.TableRow(findBy.String));
        }

        public virtual cTableRowCollection FindTableRows(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cTableRowCollection(obj.TableRows.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #region TextField

        public virtual cTextField FindTextField(DynValue findBy, DynValue s1, DynValue s2)
        {
            if (s1.IsNotNil())
                return new cTextField(obj.TextField(Helpers.ParseConstraint(findBy, s1, s2)));
            else
                return new cTextField(obj.TextField(findBy.String));
        }

        public virtual cTextFieldCollection FindTextFields(DynValue findBy, DynValue s1, DynValue s2)
        {
            return new cTextFieldCollection(obj.TextFields.Filter(Helpers.ParseConstraint(findBy, s1, s2)));
        }

        #endregion

        #endregion
    }
}