namespace MHFramework.Client;
public class AppObserver
{
    public Action<List<Guid>>? OnSelectedNodesChanged { get; set; }
    public void SelectedNodesHasChanged(List<Guid> selectedNodes)
    {
        Action<List<Guid>>? selectedNodesChanged = OnSelectedNodesChanged;
        if (selectedNodesChanged == null)
            return;
        selectedNodesChanged(selectedNodes);
    }
}