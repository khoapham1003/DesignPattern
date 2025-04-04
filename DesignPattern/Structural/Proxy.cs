using System;
using System.Collections.Generic;

//ServiceInterface
public interface IDocumentService
{
    void ViewDocument(string username);
}
// Service
public class DocumentService : IDocumentService
{
    private string _documentContent;

    public DocumentService(string content)
    {
        _documentContent = content;
    }

    public void ViewDocument(string username)
    {
        Console.WriteLine($"[DocumentService] Nội dung tài liệu: {_documentContent}");
    }
}

// Proxy
public class DocumentProxy : IDocumentService
{
    private DocumentService _realService;

    private HashSet<string> _authorizedUsers;
    private Dictionary<string, int> _viewLog;

    public DocumentProxy(string content)
    {
        _realService = new DocumentService(content);
        _authorizedUsers = new HashSet<string> { "admin", "manager" };
        _viewLog = new Dictionary<string, int>(); 
    }

    private bool CheckAccess(string username)
    {
        Console.WriteLine($"[Proxy] Kiểm tra quyền truy cập cho: {username}");
        return _authorizedUsers.Contains(username);
    }

    public void ViewDocument(string username)
    {
        if (CheckAccess(username))
        {
            // Thêm phần kiểm tra quyền truy cập ròi mới thực hiện
            _realService.ViewDocument(username);
            // Ghi log người dùng đã xem
            LogAccess(username);
        }
        else
        {
            Console.WriteLine("[Proxy] Truy cập bị từ chối! Người dùng không có quyền.");
        }
    }

    private void LogAccess(string username)
    {
        if (_viewLog.ContainsKey(username))
            _viewLog[username]++;
        else
            _viewLog[username] = 1;

        Console.WriteLine($"[Proxy] Ghi log: {username} đã xem tài liệu {_viewLog[username]} lần.");
    }
}

// Client
public class ClientDPProxy
{
    private IDocumentService _documentService;

    public ClientDPProxy(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    public void RequestView(string username)
    {
        Console.WriteLine($"\n[Client] Yêu cầu xem tài liệu từ: {username}");
        _documentService.ViewDocument(username);
    }
}
