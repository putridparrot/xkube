THIS IS VERY MUCH UNDER DEVELOPMENT AND IS A BIT OF A MESS WHILST I TRY THINGS OUT.

_I'm developing this in a public repository so, until the notice above is removed one can assume this is still very much subject to lots of changes and I'm using this to learn more about Kubernetes, so some areas may need more attention to be of use._

# xkube

The xkube project is aimed at created extensions to what kubectl can do. 

It is NOT meant to be a replacement for kubectl.

## Inspiration

Whilst there a UI tool for kubernetes that probably do some (or even all) of what I want in xkube, the aim here is to make these features available to a simple CLI, for use within a shell/terminal as well is potentially within CI pipelines - yeah I'm not quite sure what I'd use this for thee, but that's an idea to explore.

The aim of the project is also to output for the user using colours and formatting as well as options to output to JSON for use from Powershell.

## Features

### Get Command

Whilst the aim is not to try to implement all the features of kubectl, the _get_ commands do allow us to better test functionality.

* .\xkube get pods
* .\xkube get pods --json

We can use JSON from Powershell using code such as 

```
 $json = .\xkube get pods --json | ConvertFrom-Json
 $json.Name[0]
 ```

* .\xkube get nodes
* .\xkube get services

### Query Command

This is very much in the early stages of development. It appears union and * are note supported, so may need to create our own version of the eva

```
./xkube query "pods | where Name contains 'etc' or Name contains 'vpn'"
./xkube query "pods | union deployments | where Namespace contains 'kube-system'"
./xkube query "pods | summarize count() by Name | render piechart"
./xkube query "union services, pods"
```

