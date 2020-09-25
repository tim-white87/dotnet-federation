terraform {
  #   backend "gcs" {
  #     bucket  = "tf-state-prod"
  #     prefix  = "remote-state/gcs/state"
  #   }
}

module "remote-state" {
  source      = "../../../../modules/gcp/remote-state/gcs"
  bucket_name = "federation"
}
