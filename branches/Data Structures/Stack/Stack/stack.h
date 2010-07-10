#pragma once
#include <vector>
template<class T>
	struct Link
	{
		Link* next;
		T data;

		Link(const T& _data)
			: data(_data){}
	};

template<class T>
	class Stack
	{
		Link<T>* head;
		int _size;
	public:
		Stack()
			:head(0),  _size(0){}
		//Повертає 	true якщо стек порожній і false в протилежному випадку
		bool empty();
		//Повертає кількість елементів в стеку
		int size();
		//Повертає останній доданий елемент
		T& top();
		//Вилучає останній доданий елемент
		void pop();
		//Додає до стеку елемент
		void push(T );
	};


template<class T>
	bool Stack<T>::empty()
	{
		return head == 0;
	}


template<class T>
	int Stack<T>::size()
	{
		return _size;
	}


template<class T>
	T& Stack<T>::top()
	{
		if( head == 0 )
			throw "stack underflow";
		return head->data;
	}

template<class T>
	void Stack<T>::pop()
	{
		if( head == 0 )
			throw "stack underflow";

		if( _size == 1)
		{
			delete head;
			head = 0;
			_size = 0;
			return;
		}
		Link<T>* temp = head;
		head = head->next;
		delete temp;
		_size--;

	}


template<class T>
	void Stack<T>::push(T item)
	{
		_size++;
		if( head == 0 ) 
		{
			Link<T>* link = new Link<T> (item);
			head = link;
			return;
		}
		Link<T>* link = new Link<T> (item);
		if( link == 0)
				throw "stack overflow";
		link->next=head;
		head = link;
	}