using k8s.Models;
using Spectre.Console;
using XKube.Extensions;
using XKube.Ui;
using XKube.ViewModels;

namespace XKube.ViewModelExtensions;

public static class V1CertificateSigningRequestExtensions
{
    public static ICollection<CertificateSigningRequestViewModel> ToViewModel(this V1CertificateSigningRequestList list) =>
        list.Items.Select(item => item.ToViewModel()).ToArray();

    public static CertificateSigningRequestViewModel ToViewModel(this V1CertificateSigningRequest item)
    {
        return new CertificateSigningRequestViewModel
        {
            Name = item.Metadata.Name ?? string.Empty,
            CreationTimestamp = item.Metadata.CreationTimestamp.ToString() ?? string.Empty
        };
    }

    public static Grid ToGrid(this ICollection<CertificateSigningRequestViewModel> items)
    {
        return items.CreateGrid(item =>
        [
            item.Name,
            item.CreationTimestamp
        ]);
    }
}