﻿using System;
using System.Collections.Generic;
using System.Text;
using TodoItApp.Model;

namespace TodoItApp.Data
{
    public class TodoItems
    {
        static Todo[] todoArray = new Todo[0];
        public int Size()
        {
            return todoArray.Length;
        }

        public Todo[] FindAll()
        {
            return todoArray;
        }

        public Todo FindById(int todoId)
        {
            foreach (var todo in todoArray)
            {
                if (todo.TodoId == todoId)
                    return todo;
            }

            return null;

            //return Array.Find<Todo>(todos, n => n.TodoId == todoId);
        }

        public void CreateTodo(string desc)
        {
            //Function to create a new array with a bigger size to fit in the new todo

            int newLength = todoArray.Length + 1;
            Array.Resize<Todo>(ref todoArray, newLength);

            //Function to Add a todo at the end of the newly resized array

            int todoId = TodoSequencer.NextTodoId();
            todoArray[newLength - 1] = new Todo(todoId, desc);
        }
        public void Clear()
        {
            todoArray = new Todo[0];
        }

      
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] result = new Todo[0];
            foreach (var item in todoArray)
            {
                if (item.Done == doneStatus)
                {
                    Array.Resize<Todo>(ref result, result.Length + 1);
                    result[^1] = item;  
                 
                }
            }
            return result;

            //return Array.FindAll(todoArray, n => n.Done == doneStatus);
        }
        public Todo[] FindByAssignee(int personId)
        {
            return Array.FindAll(todoArray, n => n.Assignee != null && n.Assignee.PersonId == personId);
        }
        public Todo[] FindByAssignee(Person assignee)
        {
            return FindByAssignee(assignee.PersonId);
        }
        public Todo[] FindUnassignedTodoItems()
        {
            return Array.FindAll(todoArray, n => n.Assignee == null);
        }


        

        public void RemoveTodo(Todo todo)
        {
            for (int i = 0; i < todoArray.Length; i++)
            {
                if (todoArray[i] == todo)
                {
                    todoArray[i] = todoArray[todoArray.Length - 1]; 
                    Array.Resize<Todo>(ref todoArray, todoArray.Length - 1); 
                }
            }

            //todoArray = Array.FindAll<Todo>(todoArray, n => n != todo);
        }

        public void RemoveAssignee(Person assignee)
        {
            foreach (var item in todoArray)
            {
                if (item.Assignee == assignee)
                {
                    item.Assignee = null;
                }
            }
        }
    }
}
