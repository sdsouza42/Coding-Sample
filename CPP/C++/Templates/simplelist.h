#ifndef SIMPLELIST_H
#define SIMPLELIST_H

namespace Generic
{
	class ListEmpty {};

	template<typename ValueType>
	class SimpleList
	{
	private:
		class Node
		{
		public:
			Node(const ValueType& v) : value(v)
			{
				next = 0;
			}

			ValueType value;
			Node* next;
		};

		Node* front;
		Node* back;

	public:
		SimpleList()
		{
			front = back = 0;
		}

		void AddElement(const ValueType& value, bool above=false)
		{
			Node* node = new Node(value);

			if(front == 0)
				front = back = node;
			else if(above)
				node->next = front, front = node;
			else
				back->next = node, back = node;
		}

		bool HasElements() const
		{
			return front != 0;
		}

		ValueType& FirstElement() const
		{
			if(front == 0) throw ListEmpty();
			return front->value;
		}

		ValueType& LastElement() const
		{
			if(back == 0) throw ListEmpty();
			return back->value;
		}

		void RemoveElement()
		{
			if(front)
			{
				Node* node = front;
				front = front->next;
				delete node;
				if(front == 0) back = 0;
			}
		}

		~SimpleList()
		{
			while(front)
				RemoveElement();
		}

		//TO DO: Implement copy constructor and assingnment operator
		
		class Iterator
		{
		public:
			Iterator(Node* node)
			{
				current = node;
			}

			ValueType& operator*() const
			{
				return current->value;
			}

			ValueType* operator->() const
			{
				return &current->value;
			}

			bool operator!=(const Iterator& other) const
			{
				return current != other.current;
			}

			Iterator& operator++()
			{
				current = current->next;
				return *this;
			}
		private:
			Node* current;
		};

		Iterator Begin() const
		{
			return Iterator(front);
		}

		Iterator End() const
		{
			return Iterator(back->next);
		}

	};
}

#endif

