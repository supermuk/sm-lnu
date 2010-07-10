#pragma once

#define NULL 0


//����� ������
template<class TKey, class TValue>
	struct CTreeNode
	{
		//�������� �� ����� ����
		CTreeNode* left;
		//�������� �� ������� ����
		CTreeNode* right;
		//����
		TKey m_key;
		//��������
		TValue m_value;
		//������� �����
		CTreeNode():left(NULL), right(NULL), m_key(), m_value(){}
		//����� �� ������ � ���������
		CTreeNode(const TKey& key, const TValue& value):left(NULL), right(NULL),m_key(key), m_value(value){}
		//����� �� ������ � ��������� �� �������������
		CTreeNode(const TKey& key):left(NULL), right(NULL),m_key(key), m_value(){}

	};


//������� �������� ������. ���� ������� ������� ���� � ������ �� �����������,
//���� ������� ����� ���� � ������ �� ����������. 
// � ���� TKey ������ ���� ��������: operator <, operator >, operator ==
template<class TKey, class TValue>
	class CBinaryTree
	{
		//�������� �� ��������� �����
		CTreeNode<TKey, TValue>* m_root;
		// ʳ������ ����� � �����
		size_t m_size;
		//���������� ������ � ����
		void InsertSubTree(CTreeNode<TKey, TValue>* node);

	public:
		CBinaryTree();
		//����������� ���������
		CBinaryTree(const CBinaryTree&);
		//����������
		~CBinaryTree();
		//���������� � ������ ���� (����, ��������) � �������� ����
		void Insert(const TKey&, const TValue&);
		//������� �� �������� �������� ���� � �����
		bool Consist(const TKey&);
		//������� �������� � ������ �� �������� ������
		void Remove(const TKey&);
		//������� �� �������� � ������
		void Clear();
		//������� ������� �������� � �����
		size_t Size();
		//������� �������� �������� � �������� ������ ���� ����� ����, ��� ������� ������� � ����� � ������� ������
		TValue& operator[] (const TKey&);
		//���������
		CBinaryTree& operator=(const CBinaryTree&);

	};

template<class TKey, class TValue>
	CBinaryTree<TKey,TValue>::CBinaryTree()
	{
		m_root = 0;
		m_size = 0;
	}
	
template<class TKey, class TValue>
	CBinaryTree<TKey,TValue>::CBinaryTree(const CBinaryTree<TKey,TValue> & tree)
	{
		*this  = tree;
	}
template<class TKey, class TValue>
	void CBinaryTree<TKey,TValue>::Insert(const TKey& key, const TValue& value)
	{
		if( Consist(key) )
		{
			throw("key already exists");
		}
		m_size++;
		if( m_root == NULL )
		{
			m_root = new CTreeNode<TKey, TValue>(key, value);
			return;
		}
		CTreeNode<TKey, TValue>* prevNode = m_root;
		CTreeNode<TKey, TValue>* node;
		bool right = false;
		if( key > m_root->m_key)
		{
			node = m_root->right;
			right = true;
		}
		else
		{
			node = m_root->left;
		}
		while( true )
		{
			if(node == NULL)
			{
				node = new CTreeNode<TKey, TValue>(key, value);
				if(right)
				{
					prevNode->right = node;
				}
				else
				{
					prevNode->left = node;
				}
				
				return;
			}
			prevNode = node;
			if(  key > node->m_key)
			{
				node = node->right;
				right = true;
			}
			else
			{
				node = node->left;
				right = false;
			}
		}
	}

template<class TKey, class TValue>
	bool CBinaryTree<TKey,TValue>::Consist(const TKey& key)
	{
		if( m_root == NULL)
			return false;
		CTreeNode<TKey, TValue>* node = m_root;
		while(true)
		{
			if(node == NULL)
			{
				return false;
			}
			if(node->m_key == key)
			{
				return true;
			}
			if( key > node->m_key )
			{
				node = node->right;
			}
			else
			{
				node = node->left;
			}
		}
	}

template<class TKey, class TValue>
	void CBinaryTree<TKey,TValue>::Remove(const TKey& key)
	{
		if( !Consist(key) )
		{
			throw "key not exists";
		}
		m_size--;
		if(  m_root->m_key == key )
		{
			CTreeNode<TKey, TValue>* rightSubTree = m_root->right;
			CTreeNode<TKey, TValue>* tmp = m_root;
			m_root = m_root->left;
			delete tmp;
			CTreeNode<TKey, TValue>* node = m_root;
			if( node != NULL)
			{
				while( node->right != NULL )
				{
					node = node->right;
				}
				node->right = rightSubTree;
			}
			else
			{
				m_root = rightSubTree;
			}
			return;
		}
		CTreeNode<TKey, TValue>* prevNode = m_root;
		CTreeNode<TKey, TValue>* node;
		bool right = false;
		if( key > m_root->m_key)
		{
			node = m_root->right;
			right = true;
		}
		else
		{
			node = m_root->left;
		}
		while(true)
		{
			if(node->m_key == key)
			{
				CTreeNode<TKey, TValue>* rightSubTree = node->right;
				CTreeNode<TKey, TValue>* maxNode = node->left;

				if(right)
				{
					prevNode->right = node->left;
					if( maxNode == NULL )
					{
						prevNode->right = rightSubTree;
					}
				}
				else
				{
					prevNode->left = node->left;
					if( maxNode == NULL )
					{
						prevNode->right = rightSubTree;
					}

				}
				delete node;
			
				if( maxNode == NULL)
				{
					return;
				}
				while( maxNode->right != NULL )
				{
					maxNode = maxNode->right;
				}
				maxNode->right = rightSubTree;
				return;
			}
			prevNode = node;
			if(  key > node->m_key)
			{
				node = node->right;
				right = true;
			}
			else
			{
				node = node->left;
				right = false;
			}
		}

	}


template<class TKey, class TValue>
	TValue& CBinaryTree<TKey,TValue>::operator [](const TKey& key)
	{
		if(!Consist(key))
		{
			Insert(key, TValue());
		}
		CTreeNode<TKey, TValue>* node = m_root;
		while(true)
		{
			if(node->m_key == key)
			{
				return node->m_value;
			}
			if( key > node->m_key )
			{
				node = node->right;
			}
			else
			{
				node = node->left;
			}
		}
	}
template<class TKey, class TValue>
	CBinaryTree<TKey,TValue>& CBinaryTree<TKey,TValue>::operator =(const CBinaryTree<TKey,TValue> & tree)
	{
		if( *this == tree )
		{		
			return;
		}

		this->Clear();
		InsertSubTree(tree.m_root);
		return *this;
	}
template<class TKey, class TValue>
	void CBinaryTree<TKey,TValue>::Clear()
	{
		while( m_root != NULL )
		{
			Remove(m_root->m_key);
		}
		m_size = 0;
	}
template<class TKey, class TValue>
	void CBinaryTree<TKey,TValue>::InsertSubTree(CTreeNode<TKey, TValue>* node)
	{
		if( node == NULL)
		{
			return;
		}
		Insert(node->m_key, node->m_value);
		InsertSubTree(node->left);
		InsertSubTree(node->right);
	}
template<class TKey, class TValue>
	size_t CBinaryTree<TKey,TValue>::Size()
	{
		return m_size;
	}
template<class TKey, class TValue>
	CBinaryTree<TKey,TValue>::~CBinaryTree()
	{
		Clear();
	}