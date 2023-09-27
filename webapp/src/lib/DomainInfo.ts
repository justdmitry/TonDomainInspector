export class DomainAuctionInfo {
    MaxBidAddress: string = "EQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAM9c";
    MaxBidAmount: number = 0;
    AuctionEndTime: Date = new Date();
}

export class DomainDnsEntries {
    Wallet: string | null = null;
    SiteToAdnl: string | null = null;
    SiteToStorage: string | null = null;
    Storage: string | null = null;
    DnsNextResolver: string | null = null;
}

export class DomainInfo {
    FullName: string = "foundation.ton";
    Address: string = "EQCD39VS5jcptHL8vMjEXrzGaRcCVYto7HUn4bpAOg8xqB2N";
    IsDeployed: boolean = true;
    Index: string = "nH1WzBFefPbCXhJr6nfLw8sV1VEG8uOXViWRBZlj+qM=";
    CollectionAddress: string = "EQC3dNlesgVD8YbAazcauIrXBPfiVhMMr5YYk2in0Mtsz0Bz";
    Domain: string = "foundation";
    OwnerAddress: string = "EQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAM9c";
    AuctionInfo: DomainAuctionInfo | null = null;
    LastFillUpTime: Date = new Date();
    Entries: DomainDnsEntries | null = null;
}
