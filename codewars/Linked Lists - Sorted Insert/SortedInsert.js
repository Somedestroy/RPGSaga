function Node(data, next) {
    this.data = data;
    this.next = next;
  }
  
  function sortedInsert(head, data) {
    if (head == null || data < head.data) {
      return new Node(data, head);
    }
    else {
      head.next = sortedInsert(head.next, data);
      return head;
    }
  }