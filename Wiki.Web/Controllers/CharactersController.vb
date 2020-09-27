Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Wiki.Data.Entity.Context
Imports Wiki.Domain

Namespace Controllers
    Public Class CharactersController
        Inherits System.Web.Mvc.Controller

        Private db As New CharacterDbContext

        ' GET: Characters
        Function Index() As ActionResult
            Return View(db.Characters.ToList())
        End Function

        ' GET: Characters/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim character As Character = db.Characters.Find(id)
            If IsNothing(character) Then
                Return HttpNotFound()
            End If
            Return View(character)
        End Function

        ' GET: Characters/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Characters/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name,Description,Type,Origin")> ByVal character As Character) As ActionResult
            If ModelState.IsValid Then
                db.Characters.Add(character)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(character)
        End Function

        ' GET: Characters/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim character As Character = db.Characters.Find(id)
            If IsNothing(character) Then
                Return HttpNotFound()
            End If
            Return View(character)
        End Function

        ' POST: Characters/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name,Description,Type,Origin")> ByVal character As Character) As ActionResult
            If ModelState.IsValid Then
                db.Entry(character).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(character)
        End Function

        ' GET: Characters/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim character As Character = db.Characters.Find(id)
            If IsNothing(character) Then
                Return HttpNotFound()
            End If
            Return View(character)
        End Function

        ' POST: Characters/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim character As Character = db.Characters.Find(id)
            db.Characters.Remove(character)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
