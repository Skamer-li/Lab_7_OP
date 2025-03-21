using System;
using System.Collections;
using System.Collections.Generic;

namespace linked_list
{
    public class LinkedListMod : IEnumerable<float>
    {
        private class Node
        {
            public float data;
            public Node next;

            public Node(float data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }

        private int _insertionPosition = 2;
        private int _elementsCount = 0;
        private Node _head = null;

        private float FindElementByIndex(int index)
        {
            if (isEmpty() || index < 0 || index >= _elementsCount)
                throw new IndexOutOfRangeException();

            Node currentNode = _head;
            int currentIndex = 0;

            do
            {
                if (currentIndex == index)
                    return currentNode.data;

                currentNode = currentNode.next;
                currentIndex++;
            } while (currentNode != null);

            return -1f;
        }

        public float this[int index] => FindElementByIndex(index);

        public int Count() { return _elementsCount; }

        public bool isEmpty()
        {
            if (_elementsCount == 0)
                return true;
            else
                return false;
        }

        public void Add(float data)
        {
            if (isEmpty())
            {
                Node headNode = new Node(data, null);
                _head = headNode;
            }
            else if (_elementsCount <= _insertionPosition)
            {
                Node currentNode = _head;

                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                currentNode.next = new Node(data, null);
            }
            else
            {
                Node currentNode = _head;

                for (int i = 1; i < _insertionPosition; i++)
                {
                    currentNode = currentNode.next;
                }

                Node tempNode = currentNode.next;
                currentNode.next = new Node(data, tempNode);
            }

            _elementsCount++;
        }

        public void Remove(float data)
        {
            if (isEmpty())
                throw new InvalidOperationException();

            if (_head.data == data)
            {
                if (_elementsCount == 1)
                    _head = null;
                else
                    _head = _head.next;

                _elementsCount--;
                return;
            }

            Node currentNode = _head;

            while (currentNode.next != null)
            {
                if (currentNode.next.data == data)
                {
                    currentNode.next = currentNode.next.next;
                    _elementsCount--;
                    return;
                }

                currentNode = currentNode.next;
            }

            throw new InvalidOperationException();
        }

        public bool Contains(float data)
        {
            if (isEmpty())
                return false;

            foreach (float listElement in this)
                if (listElement == data)
                    return true;

            return false;
        }

        public IEnumerator<float> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
