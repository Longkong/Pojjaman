-- �� bug ������ approve �� reject
update [StockiApprovalStoreComment]
set [apvstore_approveType] = -1
where [apvstore_approveType] <> 1